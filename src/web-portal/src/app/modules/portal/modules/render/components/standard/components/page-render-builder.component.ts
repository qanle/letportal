import { Component, OnInit, ContentChildren, ViewChildren, QueryList, Input, AfterViewInit, AfterContentInit, ChangeDetectorRef, AfterViewChecked, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { PageRenderSectionWrapperComponent } from './page-render-section-wrapper.component';
import { Page, PageButton, PageSection } from 'services/portal.service';
import { Store } from '@ngxs/store';
import { Observable, of, Subscription } from 'rxjs';
import { PageStateModel } from 'stores/pages/page.state';
import { filter, tap, delay } from 'rxjs/operators';
import { PageReadyAction, BeginRenderingPageSectionsAction, RenderedPageSectionAction, EndRenderingPageSectionsAction, BeginBuildingBoundData, AddSectionBoundData, EndBuildingBoundDataComplete } from 'stores/pages/page.actions';
import * as _ from 'lodash';
import { RenderingPageSectionState, RenderingSectionState } from 'app/core/models/page.model';
import { NGXLogger } from 'ngx-logger';
import { ExtendedPageButton } from 'app/core/models/extended.models';
import { PageService } from 'services/page.service';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';

@Component({
    selector: 'let-builder',
    templateUrl: './page-render-builder.component.html'
})
export class PageRenderBuilderComponent implements OnInit, AfterViewInit, AfterContentInit, AfterViewChecked, OnDestroy {

    @ViewChildren(PageRenderSectionWrapperComponent) renderSections: QueryList<PageRenderSectionWrapperComponent>

    @Input()
    page: Page

    isReadyToRender = false
    pageState$: Observable<PageStateModel>
    subscribe$: Subscription
    options: any
    queryparams: any
    counterRenderedSection = 0
    counterBuildSectionData = 0

    sectionClasses: string[] = []

    renderingSections: RenderingPageSectionState[] = []
    actionCommands: PageButton[] = []
    isSmallDevice = false
    constructor(
        private store: Store,
        private logger: NGXLogger,
        private cd: ChangeDetectorRef,
        private pageService: PageService,
        private breakpointObserver: BreakpointObserver
    ) {
        this.pageState$ = this.store.select(state => state.page)
        this.breakpointObserver.observe([
            Breakpoints.HandsetPortrait,
            Breakpoints.HandsetLandscape
        ]).subscribe(result => {
            if (result.matches) {                
                this.isSmallDevice = true
                this.cd.markForCheck()
            }
            else{
                this.isSmallDevice = false
                this.cd.markForCheck()
            }
        });
    }
    data: any
    readyToRenderButtons = false
    readyToRenderAllSections = false
    ngOnInit(): void {
        this.logger.debug('Init render builder')
        _.forEach(this.page.builder.sections, sec =>{
            this.sectionClasses.push('col-lg-12')
        })
        this.actionCommands = this.page.commands
        const sub$ = this.pageService.listenDataChange$().subscribe(
            data => {
                this.data = data
                _.forEach(this.actionCommands, (command: ExtendedPageButton) => {
                    command.isHidden = this.pageService.evaluatedExpression(command.allowHidden)                    
                })
                this.readyToRenderButtons = true
                sub$.unsubscribe()
            }
        )
        this.subscribe$ = this.pageState$.pipe(
            filter(state => state.filterState &&
                (state.filterState === PageReadyAction
                    || state.filterState === RenderedPageSectionAction
                    || state.filterState === AddSectionBoundData)),
            tap(
                pageState => {
                    switch (pageState.filterState) {
                        case PageReadyAction:
                            this.isReadyToRender = true
                            this.options = pageState.options
                            this.queryparams = pageState.queryparams
                            this.counterRenderedSection = this.page.builder.sections.length
                            this.counterBuildSectionData = this.page.builder.sections.length
                            this.store.dispatch(new BeginRenderingPageSectionsAction(this.prepareRenderingPageSectionsStates(this.page)))
                            break
                        case RenderedPageSectionAction:                            
                            this.counterRenderedSection--
                            if (this.counterRenderedSection === 0) {
                                const timer$ = of(true).pipe(
                                    delay(500),
                                    tap(
                                        () => {
                                            this.readyToRenderAllSections = true
                                            _.forEach(pageState.renderingSections, sec => {
                                                const index = _.findIndex(this.page.builder.sections, a => a.name === sec.sectionName)
                                                this.sectionClasses[index] = sec.sectionClass
                                            })
                                            this.store.dispatch(new EndRenderingPageSectionsAction())
                                            this.store.dispatch(new BeginBuildingBoundData())
                                            timer$.unsubscribe()
                                        }
                                    )
                                ).subscribe()
                            }
                            break
                        case AddSectionBoundData:
                            this.counterBuildSectionData--
                            if (this.counterBuildSectionData === 0) {
                                const timer$ = of(true).pipe(
                                    delay(200),
                                    tap(
                                        () => {
                                            this.store.dispatch(new EndBuildingBoundDataComplete())
                                            timer$.unsubscribe()
                                        }
                                    )
                                ).subscribe()
                            }
                            break

                    }
                }
            )
        ).subscribe()
    }

    ngAfterContentInit(): void {
    }
    ngAfterViewInit(): void {
    }

    ngAfterViewChecked(): void {
    }
    ngOnDestroy(): void {
        this.subscribe$.unsubscribe()
    }

    prepareRenderingPageSectionsStates(page: Page) {
        _.forEach(page.builder.sections, section => {
            this.renderingSections.push({
                sectionName: section.name,
                sectionClass: 'col-lg-12',
                state: RenderingSectionState.Init
            })
        })

        return this.renderingSections
    }

    onCommandClick(command: ExtendedPageButton) {
        this.pageService.executeCommand(command)
    }

    getSectionClass(section: PageSection){
        if(this.readyToRenderAllSections){
            return this.renderingSections.find(a => a.sectionName == section.name).sectionClass
        }
        else{
            return 'hidden'
        }
    }
}
