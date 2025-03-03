import {
  MatAccordion,
  MatExpansionModule,
  MatExpansionPanel,
  MatExpansionPanelHeader,
  MatExpansionPanelTitle
} from "./chunk-A4RMTSFK.js";
import {
  OpenSettingsService
} from "./chunk-I6EEGYC4.js";
import {
  MatProgressBar,
  MatProgressBarModule,
  MatSelect,
  MatSelectModule
} from "./chunk-S64WAFEK.js";
import {
  MatMenu,
  MatMenuItem,
  MatMenuModule,
  MatMenuTrigger
} from "./chunk-SDNNC3I4.js";
import {
  ConfirmationDialogComponent,
  MatDialog
} from "./chunk-HQT7NEGY.js";
import {
  FormsModule,
  MatCard,
  MatCardContent,
  MatCardImage,
  MatCardModule,
  MatFormField,
  MatIcon,
  MatIconModule,
  MatIconRegistry,
  MatLabel,
  MatSuffix,
  MatTooltip,
  MatTooltipModule,
  NgControlStatus,
  NgModel
} from "./chunk-AXECPBMH.js";
import {
  CommonModule,
  DatePipe,
  DomSanitizer,
  KeyValuePipe,
  MatButton,
  MatButtonModule,
  MatFabButton,
  MatIconButton,
  MatOption,
  NgClass,
  NgForOf,
  NgIf,
  Router,
  RouterModule,
  Subscription,
  WindowService,
  __spreadValues,
  inject,
  ɵsetClassDebugInfo,
  ɵɵadvance,
  ɵɵdefineComponent,
  ɵɵdefineInjector,
  ɵɵdefineNgModule,
  ɵɵdirectiveInject,
  ɵɵelement,
  ɵɵelementEnd,
  ɵɵelementStart,
  ɵɵgetCurrentView,
  ɵɵlistener,
  ɵɵloadQuery,
  ɵɵnextContext,
  ɵɵpipe,
  ɵɵpipeBind1,
  ɵɵpipeBind2,
  ɵɵproperty,
  ɵɵpropertyInterpolate,
  ɵɵpureFunction1,
  ɵɵqueryRefresh,
  ɵɵreference,
  ɵɵresetView,
  ɵɵrestoreView,
  ɵɵsanitizeUrl,
  ɵɵtemplate,
  ɵɵtemplateRefExtractor,
  ɵɵtext,
  ɵɵtextInterpolate,
  ɵɵtextInterpolate1,
  ɵɵtwoWayBindingSet,
  ɵɵtwoWayListener,
  ɵɵtwoWayProperty,
  ɵɵviewQuery
} from "./chunk-SUR7UARE.js";

// src/app/features/sponsor/components/sponsor-list/sponsor-list.component.ts
var _c0 = (a0) => ({ "past-sponsor": a0 });
function SponsorListComponent_mat_option_12_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-option", 9);
    \u0275\u0275text(1, "Past sponsors");
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    \u0275\u0275property("value", 0);
  }
}
function SponsorListComponent_mat_option_27_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-option", 9);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const class_r2 = ctx.$implicit;
    \u0275\u0275property("value", class_r2.key);
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(class_r2.value.name);
  }
}
function SponsorListComponent_button_29_Template(rf, ctx) {
  if (rf & 1) {
    const _r3 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 21);
    \u0275\u0275listener("click", function SponsorListComponent_button_29_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r3);
      const ctx_r3 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r3.clearFilter());
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "clear");
    \u0275\u0275elementEnd();
    \u0275\u0275text(3, " Clear filter ");
    \u0275\u0275elementEnd();
  }
}
function SponsorListComponent_mat_accordion_37_mat_expansion_panel_1_span_3_mat_icon_1_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "mat-icon", 30);
  }
  if (rf & 2) {
    const mapping_r5 = \u0275\u0275nextContext().ngIf;
    \u0275\u0275propertyInterpolate("svgIcon", mapping_r5.iconName);
  }
}
function SponsorListComponent_mat_accordion_37_mat_expansion_panel_1_span_3_ng_template_2_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-icon", 31);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const mapping_r5 = \u0275\u0275nextContext().ngIf;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(mapping_r5.iconName !== "" ? mapping_r5.iconName : "coffee");
  }
}
function SponsorListComponent_mat_accordion_37_mat_expansion_panel_1_span_3_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "span", 28);
    \u0275\u0275template(1, SponsorListComponent_mat_accordion_37_mat_expansion_panel_1_span_3_mat_icon_1_Template, 1, 1, "mat-icon", 29)(2, SponsorListComponent_mat_accordion_37_mat_expansion_panel_1_span_3_ng_template_2_Template, 2, 1, "ng-template", null, 3, \u0275\u0275templateRefExtractor);
    \u0275\u0275text(4);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const mapping_r5 = ctx.ngIf;
    const matIcon_r6 = \u0275\u0275reference(3);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", mapping_r5.svgIconDef)("ngIfElse", matIcon_r6);
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate1("| ", mapping_r5.name, " ");
  }
}
function SponsorListComponent_mat_accordion_37_mat_expansion_panel_1_mat_card_5_a_6_Template(rf, ctx) {
  if (rf & 1) {
    const _r7 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "a", 39);
    \u0275\u0275listener("click", function SponsorListComponent_mat_accordion_37_mat_expansion_panel_1_mat_card_5_a_6_Template_a_click_0_listener($event) {
      \u0275\u0275restoreView(_r7);
      const sponsor_r8 = \u0275\u0275nextContext().$implicit;
      const ctx_r3 = \u0275\u0275nextContext(3);
      return \u0275\u0275resetView(ctx_r3.confirmationRequiredToOpenLink(sponsor_r8.url, $event));
    });
    \u0275\u0275element(1, "mat-icon", 40);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const sponsor_r8 = \u0275\u0275nextContext().$implicit;
    \u0275\u0275property("href", sponsor_r8.url, \u0275\u0275sanitizeUrl);
  }
}
function SponsorListComponent_mat_accordion_37_mat_expansion_panel_1_mat_card_5_mat_icon_7_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-icon", 41);
    \u0275\u0275pipe(1, "date");
    \u0275\u0275text(2, "info");
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const sponsor_r8 = \u0275\u0275nextContext().$implicit;
    \u0275\u0275property("matTooltip", "From " + \u0275\u0275pipeBind2(1, 1, sponsor_r8.createdOn, "mediumDate"));
  }
}
function SponsorListComponent_mat_accordion_37_mat_expansion_panel_1_mat_card_5_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-card", 32)(1, "div", 33);
    \u0275\u0275element(2, "img", 34);
    \u0275\u0275elementStart(3, "div", 35)(4, "mat-card-content", 36);
    \u0275\u0275text(5);
    \u0275\u0275template(6, SponsorListComponent_mat_accordion_37_mat_expansion_panel_1_mat_card_5_a_6_Template, 2, 1, "a", 37);
    \u0275\u0275elementEnd()()();
    \u0275\u0275template(7, SponsorListComponent_mat_accordion_37_mat_expansion_panel_1_mat_card_5_mat_icon_7_Template, 3, 4, "mat-icon", 38);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const sponsor_r8 = ctx.$implicit;
    \u0275\u0275property("ngClass", \u0275\u0275pureFunction1(6, _c0, !sponsor_r8.isActive));
    \u0275\u0275advance(2);
    \u0275\u0275property("src", sponsor_r8.imageUrl, \u0275\u0275sanitizeUrl)("alt", sponsor_r8.name + " IMG");
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate1(" ", sponsor_r8.name, " ");
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", sponsor_r8.url && sponsor_r8.isActive);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", sponsor_r8.isActive);
  }
}
function SponsorListComponent_mat_accordion_37_mat_expansion_panel_1_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-expansion-panel", 24)(1, "mat-expansion-panel-header")(2, "mat-panel-title");
    \u0275\u0275template(3, SponsorListComponent_mat_accordion_37_mat_expansion_panel_1_span_3_Template, 5, 3, "span", 25);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(4, "div", 26);
    \u0275\u0275template(5, SponsorListComponent_mat_accordion_37_mat_expansion_panel_1_mat_card_5_Template, 8, 8, "mat-card", 27);
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const entry_r9 = ctx.$implicit;
    const ctx_r3 = \u0275\u0275nextContext(2);
    \u0275\u0275advance(3);
    \u0275\u0275property("ngIf", ctx_r3.selectedRawResponseData.classIdMappings[entry_r9.key]);
    \u0275\u0275advance(2);
    \u0275\u0275property("ngForOf", entry_r9.value);
  }
}
function SponsorListComponent_mat_accordion_37_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-accordion", 22);
    \u0275\u0275template(1, SponsorListComponent_mat_accordion_37_mat_expansion_panel_1_Template, 6, 2, "mat-expansion-panel", 23);
    \u0275\u0275pipe(2, "keyvalue");
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r3 = \u0275\u0275nextContext();
    \u0275\u0275advance();
    \u0275\u0275property("ngForOf", \u0275\u0275pipeBind1(2, 1, ctx_r3.filteredSponsors));
  }
}
function SponsorListComponent_ng_template_38_button_0_Template(rf, ctx) {
  if (rf & 1) {
    const _r10 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 43);
    \u0275\u0275listener("click", function SponsorListComponent_ng_template_38_button_0_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r10);
      const ctx_r3 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r3.openBecomeSponsorMenu());
    });
    \u0275\u0275text(1);
    \u0275\u0275element(2, "mat-icon", 44);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r3 = \u0275\u0275nextContext(2);
    \u0275\u0275advance();
    \u0275\u0275textInterpolate1(" We currently don't have any sponsors", ctx_r3.selectedClassFilter === null ? "" : " for this category", ", but that's okay! Our mission goes beyond this. ");
  }
}
function SponsorListComponent_ng_template_38_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275template(0, SponsorListComponent_ng_template_38_button_0_Template, 3, 1, "button", 42);
  }
  if (rf & 2) {
    const ctx_r3 = \u0275\u0275nextContext();
    \u0275\u0275property("ngIf", ctx_r3.selectedStatusFilter !== 0);
  }
}
function SponsorListComponent_a_46_mat_icon_3_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "mat-icon", 47);
  }
  if (rf & 2) {
    const link_r11 = \u0275\u0275nextContext().$implicit;
    \u0275\u0275propertyInterpolate("svgIcon", link_r11.iconName);
  }
}
function SponsorListComponent_a_46_ng_template_4_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-icon");
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const link_r11 = \u0275\u0275nextContext().$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(link_r11.iconName !== "" ? link_r11.iconName : "favorite");
  }
}
function SponsorListComponent_a_46_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "a", 45)(1, "span");
    \u0275\u0275text(2);
    \u0275\u0275elementEnd();
    \u0275\u0275template(3, SponsorListComponent_a_46_mat_icon_3_Template, 1, 1, "mat-icon", 46)(4, SponsorListComponent_a_46_ng_template_4_Template, 2, 1, "ng-template", null, 3, \u0275\u0275templateRefExtractor);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const link_r11 = ctx.$implicit;
    const matIcon_r12 = \u0275\u0275reference(5);
    \u0275\u0275property("href", link_r11.url, \u0275\u0275sanitizeUrl);
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate(link_r11.name);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", link_r11.svgIconDef)("ngIfElse", matIcon_r12);
  }
}
function SponsorListComponent_mat_progress_bar_47_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "mat-progress-bar", 48);
  }
}
var _SponsorListComponent = class _SponsorListComponent {
  constructor(openSettingsService, iconRegistry, sanitizer, windowService, dialog) {
    this.openSettingsService = openSettingsService;
    this.iconRegistry = iconRegistry;
    this.sanitizer = sanitizer;
    this.windowService = windowService;
    this.dialog = dialog;
    this.subscriptions = new Subscription();
    this.selectedStatusFilter = 1;
    this.selectedVersionFilter = 1;
    this.selectedClassFilter = null;
    this.failedToFetchLatestVersion = false;
    this.isRawDataFromService = false;
    this.hasAnySponsors = true;
    this.hasPastSponsors = true;
    this.isLoading = false;
    this.selectedRawResponseData = {
      becomeSponsorLinks: [],
      classIdMappings: {},
      frequencyIdMappings: {},
      sponsors: []
    };
    this.rawResponseDataFromFallback = null;
    this.rawResponseDataFromService = null;
    this.filteredSponsors = {};
  }
  ngOnInit() {
    this.packVersion = this.windowService.packVersion;
    this.startFetching();
    const subscription = this.openSettingsService.getSponsors().subscribe({
      next: (response) => {
        this.failedToFetchLatestVersion = response.fromFallback;
        this.selectedRawResponseData = response.data;
        if (this.failedToFetchLatestVersion) {
          this.rawResponseDataFromFallback = __spreadValues({}, response.data);
          this.isRawDataFromService = false;
          this.selectedVersionFilter = 0;
        } else {
          this.rawResponseDataFromService = __spreadValues({}, response.data);
          this.isRawDataFromService = true;
        }
        this.handleClassIdMappings(response.data.classIdMappings);
        this.handleBecomeSponsorLinks(response.data.becomeSponsorLinks);
        this.reloadData();
      },
      error: () => {
        this.stopFetching();
      }
    });
    this.subscriptions.add(subscription);
  }
  filterSponsorsVersion() {
    if (this.selectedVersionFilter === 1 && this.rawResponseDataFromService && !this.isRawDataFromService) {
      this.switchToVersionData(this.rawResponseDataFromService);
    } else if (this.selectedVersionFilter === 0 && this.rawResponseDataFromFallback && this.isRawDataFromService) {
      this.switchToVersionData(this.rawResponseDataFromFallback);
    } else if (this.selectedVersionFilter === 0 && !this.rawResponseDataFromFallback) {
      this.fetchFallbackSponsors();
    } else {
      this.reloadData();
    }
  }
  switchToVersionData(versionData) {
    this.selectedRawResponseData = __spreadValues({}, versionData);
    this.isRawDataFromService = !this.isRawDataFromService;
    this.handleClassIdMappings(versionData.classIdMappings);
    this.handleBecomeSponsorLinks(versionData.becomeSponsorLinks);
    this.reloadData();
  }
  fetchFallbackSponsors() {
    const subscription = this.openSettingsService.getSponsorsFromFallback().subscribe((response) => {
      this.rawResponseDataFromFallback = __spreadValues({}, response.data);
      this.switchToVersionData(response.data);
    });
    this.subscriptions.add(subscription);
  }
  startFetching() {
    this.isLoading = true;
  }
  stopFetching() {
    this.isLoading = false;
  }
  reloadData() {
    let sponsors = this.selectedRawResponseData.sponsors;
    this.hasPastSponsors = sponsors.some((s) => !s.isActive);
    if (this.selectedStatusFilter !== null) {
      sponsors = sponsors.filter((s) => this.selectedStatusFilter === 1 ? s.isActive : !s.isActive);
    }
    if (this.selectedClassFilter !== null) {
      sponsors = sponsors.filter((s) => s.classId == this.selectedClassFilter);
    }
    this.filteredSponsors = this.groupAndSortSponsors(sponsors);
    this.hasAnySponsors = Object.keys(this.filteredSponsors).length > 0;
    this.stopFetching();
  }
  groupAndSortSponsors(sponsors) {
    const groupedSponsors = sponsors.sort((a, b) => a.classId - b.classId).reduce((acc, sponsor) => {
      const classKey = sponsor.classId;
      if (!acc[classKey])
        acc[classKey] = [];
      acc[classKey].push(sponsor);
      return acc;
    }, {});
    for (const key in groupedSponsors) {
      if (Object.prototype.hasOwnProperty.call(groupedSponsors, key)) {
        groupedSponsors[key].sort((a, b) => {
          if (a.isActive !== b.isActive) {
            return a.isActive ? -1 : 1;
          }
          return a.sortOrder - b.sortOrder;
        });
      }
    }
    return groupedSponsors;
  }
  handleClassIdMappings(classIdMappings) {
    Object.values(classIdMappings).forEach((model) => {
      if (model.svgIconDef && model.iconName) {
        this.iconRegistry.addSvgIconLiteral(model.iconName, this.sanitizer.bypassSecurityTrustHtml(model.svgIconDef));
      }
    });
  }
  handleBecomeSponsorLinks(becomeSponsorLinks) {
    becomeSponsorLinks.forEach((link) => {
      if (link.svgIconDef && link.iconName) {
        this.iconRegistry.addSvgIconLiteral(link.iconName, this.sanitizer.bypassSecurityTrustHtml(link.svgIconDef));
      }
    });
  }
  openBecomeSponsorMenu() {
    if (this.selectedRawResponseData.becomeSponsorLinks.length === 1) {
      this.openLink(this.selectedRawResponseData.becomeSponsorLinks[0].url);
    } else {
      this.matMenuTrigger?.openMenu();
    }
  }
  confirmationRequiredToOpenLink(url, event) {
    event.preventDefault();
    const title = "Warn!";
    const message = `You are about to navigating to an external website. Do you want to proceed? <br /><br />Url: <small><q>${url}</q></small>`;
    const subscription = this.dialog.open(ConfirmationDialogComponent, {
      width: "500px",
      data: { title, message }
    }).afterClosed().subscribe((result) => {
      if (result) {
        this.openLink(url);
      }
    });
    this.subscriptions.add(subscription);
  }
  openLink(url) {
    window.open(url, "_blank");
  }
  clearFilter() {
    this.selectedStatusFilter = null;
    this.selectedClassFilter = null;
    if (!this.failedToFetchLatestVersion) {
      this.selectedVersionFilter = 1;
      this.filterSponsorsVersion();
    } else {
      this.reloadData();
    }
  }
  expandAll() {
    this.accordion.openAll();
  }
  collapseAll() {
    this.accordion.closeAll();
  }
};
_SponsorListComponent.\u0275fac = function SponsorListComponent_Factory(t) {
  return new (t || _SponsorListComponent)(\u0275\u0275directiveInject(OpenSettingsService), \u0275\u0275directiveInject(MatIconRegistry), \u0275\u0275directiveInject(DomSanitizer), \u0275\u0275directiveInject(WindowService), \u0275\u0275directiveInject(MatDialog));
};
_SponsorListComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _SponsorListComponent, selectors: [["ng-component"]], viewQuery: function SponsorListComponent_Query(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275viewQuery(MatAccordion, 5);
    \u0275\u0275viewQuery(MatMenuTrigger, 5);
  }
  if (rf & 2) {
    let _t;
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.accordion = _t.first);
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.matMenuTrigger = _t.first);
  }
}, decls: 48, vars: 19, consts: [["filterSelect", ""], ["noSponsors", ""], ["sponsorMenu", "matMenu"], ["matIcon", ""], [1, "px-3"], [1, "title", "mb-3"], [1, "d-flex"], ["appearance", "outline", 1, "w-25", "mr-2", "border-bottom-1"], [3, "ngModelChange", "ngModel"], [3, "value"], [3, "value", 4, "ngIf"], [3, "value", "disabled"], [3, "value", 4, "ngFor", "ngForOf"], ["class", "mt-2", "mat-stroked-button", "", "color", "primary", 3, "click", 4, "ngIf"], [1, "spacer"], ["mat-icon-button", "", "matTooltip", "Expand All", 3, "click"], ["mat-icon-button", "", "matTooltip", "Collapse All", 3, "click"], ["multi", "", 4, "ngIf", "ngIfElse"], ["mat-fab", "", "extended", "", "color", "primary", "matTooltip", "Become a sponsor", 1, "position-fixed", "b-0", "r-0", "mr-3", "mb-3", 3, "click", "matMenuTriggerFor"], ["mat-menu-item", "", "target", "_blank", 3, "href", 4, "ngFor", "ngForOf"], ["mode", "indeterminate", "class", "position-fixed l-0 b-0", 4, "ngIf"], ["mat-stroked-button", "", "color", "primary", 1, "mt-2", 3, "click"], ["multi", ""], ["expanded", "true", 4, "ngFor", "ngForOf"], ["expanded", "true"], ["style", "display: inline-flex; align-items: center;", 4, "ngIf"], [1, "card-container"], ["class", "card-item mb-2", "appearance", "outlined", 3, "ngClass", 4, "ngFor", "ngForOf"], [2, "display", "inline-flex", "align-items", "center"], ["class", "mr-2", 3, "svgIcon", 4, "ngIf", "ngIfElse"], [1, "mr-2", 3, "svgIcon"], [1, "mr-2"], ["appearance", "outlined", 1, "card-item", "mb-2", 3, "ngClass"], [1, "card-image-container"], ["mat-card-image", "", 3, "src", "alt"], [1, "card-overlay"], [2, "padding", "8px"], ["class", "card-link", "target", "_blank", 3, "href", "click", 4, "ngIf"], ["class", "position-absolute t-0 r-0 p-1", "matTooltipPosition", "above", 3, "matTooltip", 4, "ngIf"], ["target", "_blank", 1, "card-link", 3, "click", "href"], ["fontIcon", "open_in_new"], ["matTooltipPosition", "above", 1, "position-absolute", "t-0", "r-0", "p-1", 3, "matTooltip"], ["color", "", "mat-fab", "", "extended", "", "matIconSuffix", "", "class", "position-fixed b-0 r-0 mr-3 mb-3 l-0", 3, "disabled", "click", 4, "ngIf"], ["color", "", "mat-fab", "", "extended", "", "matIconSuffix", "", 1, "position-fixed", "b-0", "r-0", "mr-3", "mb-3", "l-0", 3, "click", "disabled"], ["matIconSuffix", "", "fontIcon", "mood"], ["mat-menu-item", "", "target", "_blank", 3, "href"], [3, "svgIcon", 4, "ngIf", "ngIfElse"], [3, "svgIcon"], ["mode", "indeterminate", 1, "position-fixed", "l-0", "b-0"]], template: function SponsorListComponent_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div", 4)(1, "div", 5)(2, "h1");
    \u0275\u0275text(3, "Sponsors");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(4, "div", 6)(5, "mat-form-field", 7)(6, "mat-label");
    \u0275\u0275text(7, "Filter by status");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(8, "mat-select", 8, 0);
    \u0275\u0275twoWayListener("ngModelChange", function SponsorListComponent_Template_mat_select_ngModelChange_8_listener($event) {
      \u0275\u0275restoreView(_r1);
      \u0275\u0275twoWayBindingSet(ctx.selectedStatusFilter, $event) || (ctx.selectedStatusFilter = $event);
      return \u0275\u0275resetView($event);
    });
    \u0275\u0275listener("ngModelChange", function SponsorListComponent_Template_mat_select_ngModelChange_8_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.reloadData());
    });
    \u0275\u0275elementStart(10, "mat-option", 9);
    \u0275\u0275text(11, "Current sponsors");
    \u0275\u0275elementEnd();
    \u0275\u0275template(12, SponsorListComponent_mat_option_12_Template, 2, 1, "mat-option", 10);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(13, "mat-form-field", 7)(14, "mat-label");
    \u0275\u0275text(15, "Filter by version");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(16, "mat-select", 8, 0);
    \u0275\u0275twoWayListener("ngModelChange", function SponsorListComponent_Template_mat_select_ngModelChange_16_listener($event) {
      \u0275\u0275restoreView(_r1);
      \u0275\u0275twoWayBindingSet(ctx.selectedVersionFilter, $event) || (ctx.selectedVersionFilter = $event);
      return \u0275\u0275resetView($event);
    });
    \u0275\u0275listener("ngModelChange", function SponsorListComponent_Template_mat_select_ngModelChange_16_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.filterSponsorsVersion());
    });
    \u0275\u0275elementStart(18, "mat-option", 11);
    \u0275\u0275text(19);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(20, "mat-option", 9);
    \u0275\u0275text(21);
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(22, "mat-form-field", 7)(23, "mat-label");
    \u0275\u0275text(24, "Filter by class");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(25, "mat-select", 8, 0);
    \u0275\u0275twoWayListener("ngModelChange", function SponsorListComponent_Template_mat_select_ngModelChange_25_listener($event) {
      \u0275\u0275restoreView(_r1);
      \u0275\u0275twoWayBindingSet(ctx.selectedClassFilter, $event) || (ctx.selectedClassFilter = $event);
      return \u0275\u0275resetView($event);
    });
    \u0275\u0275listener("ngModelChange", function SponsorListComponent_Template_mat_select_ngModelChange_25_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.reloadData());
    });
    \u0275\u0275template(27, SponsorListComponent_mat_option_27_Template, 2, 2, "mat-option", 12);
    \u0275\u0275pipe(28, "keyvalue");
    \u0275\u0275elementEnd()();
    \u0275\u0275template(29, SponsorListComponent_button_29_Template, 4, 0, "button", 13);
    \u0275\u0275element(30, "span", 14);
    \u0275\u0275elementStart(31, "button", 15);
    \u0275\u0275listener("click", function SponsorListComponent_Template_button_click_31_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.expandAll());
    });
    \u0275\u0275elementStart(32, "mat-icon");
    \u0275\u0275text(33, "expand_more");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(34, "button", 16);
    \u0275\u0275listener("click", function SponsorListComponent_Template_button_click_34_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.collapseAll());
    });
    \u0275\u0275elementStart(35, "mat-icon");
    \u0275\u0275text(36, "expand_less");
    \u0275\u0275elementEnd()()();
    \u0275\u0275template(37, SponsorListComponent_mat_accordion_37_Template, 3, 3, "mat-accordion", 17)(38, SponsorListComponent_ng_template_38_Template, 1, 1, "ng-template", null, 1, \u0275\u0275templateRefExtractor);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(40, "button", 18);
    \u0275\u0275listener("click", function SponsorListComponent_Template_button_click_40_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.selectedRawResponseData.becomeSponsorLinks.length === 1 && ctx.openLink(ctx.selectedRawResponseData.becomeSponsorLinks[0].url));
    });
    \u0275\u0275text(41, " Sponsor ");
    \u0275\u0275elementStart(42, "mat-icon");
    \u0275\u0275text(43, "favorite");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(44, "mat-menu", null, 2);
    \u0275\u0275template(46, SponsorListComponent_a_46_Template, 6, 4, "a", 19);
    \u0275\u0275elementEnd();
    \u0275\u0275template(47, SponsorListComponent_mat_progress_bar_47_Template, 1, 0, "mat-progress-bar", 20);
  }
  if (rf & 2) {
    const noSponsors_r13 = \u0275\u0275reference(39);
    const sponsorMenu_r14 = \u0275\u0275reference(45);
    \u0275\u0275advance(8);
    \u0275\u0275twoWayProperty("ngModel", ctx.selectedStatusFilter);
    \u0275\u0275advance(2);
    \u0275\u0275property("value", 1);
    \u0275\u0275advance(2);
    \u0275\u0275property("ngIf", ctx.hasPastSponsors);
    \u0275\u0275advance(4);
    \u0275\u0275twoWayProperty("ngModel", ctx.selectedVersionFilter);
    \u0275\u0275advance(2);
    \u0275\u0275property("value", 1)("disabled", ctx.failedToFetchLatestVersion);
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(ctx.failedToFetchLatestVersion ? "Latest (failed to fetch)" : "Latest");
    \u0275\u0275advance();
    \u0275\u0275property("value", 0);
    \u0275\u0275advance();
    \u0275\u0275textInterpolate("v" + ctx.packVersion);
    \u0275\u0275advance(4);
    \u0275\u0275twoWayProperty("ngModel", ctx.selectedClassFilter);
    \u0275\u0275advance(2);
    \u0275\u0275property("ngForOf", \u0275\u0275pipeBind1(28, 17, ctx.selectedRawResponseData.classIdMappings));
    \u0275\u0275advance(2);
    \u0275\u0275property("ngIf", ctx.selectedStatusFilter !== null || ctx.selectedVersionFilter === 0 && !ctx.failedToFetchLatestVersion || ctx.selectedClassFilter !== null);
    \u0275\u0275advance(8);
    \u0275\u0275property("ngIf", ctx.hasAnySponsors)("ngIfElse", noSponsors_r13);
    \u0275\u0275advance(3);
    \u0275\u0275property("matMenuTriggerFor", ctx.selectedRawResponseData.becomeSponsorLinks.length > 1 ? sponsorMenu_r14 : null);
    \u0275\u0275advance(6);
    \u0275\u0275property("ngForOf", ctx.selectedRawResponseData.becomeSponsorLinks);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.isLoading);
  }
}, dependencies: [NgClass, NgForOf, NgIf, NgControlStatus, NgModel, MatFormField, MatLabel, MatSuffix, MatSelect, MatOption, MatIcon, MatAccordion, MatExpansionPanel, MatExpansionPanelHeader, MatExpansionPanelTitle, MatCard, MatCardContent, MatCardImage, MatMenu, MatMenuItem, MatMenuTrigger, MatProgressBar, MatTooltip, MatButton, MatIconButton, MatFabButton, DatePipe, KeyValuePipe], styles: ["\n\n.card-item[_ngcontent-%COMP%] {\n  flex-basis: calc(16.2% - 4px);\n  position: relative;\n  height: 150px;\n  overflow: hidden;\n}\n.card-image-container[_ngcontent-%COMP%] {\n  position: relative;\n  width: 100%;\n  height: 100%;\n}\n.card-image-container[_ngcontent-%COMP%]   img[_ngcontent-%COMP%] {\n  width: 100%;\n  height: 100%;\n  object-fit: cover;\n}\n.card-overlay[_ngcontent-%COMP%] {\n  position: absolute;\n  bottom: 0;\n  width: 100%;\n  background: rgba(0, 0, 0, 0.62);\n  color: white;\n  text-align: center;\n}\n.card-container[_ngcontent-%COMP%] {\n  display: flex;\n  flex-wrap: wrap;\n  justify-content: space-around;\n}\n.card-link[_ngcontent-%COMP%] {\n  position: absolute;\n  right: 5px;\n  top: 5px;\n}\n.past-sponsor[_ngcontent-%COMP%] {\n  opacity: 0.5;\n  pointer-events: none;\n}\n  .border-bottom-1 .mdc-notched-outline__leading,   .border-bottom-1 .mdc-notched-outline__notch,   .border-bottom-1 .mdc-notched-outline__trailing {\n  border-bottom: 1px inset !important;\n  border: 0px;\n  border-radius: 0 !important;\n}\n  .border-none .mdc-notched-outline__leading,   .border-none .mdc-notched-outline__notch,   .border-none .mdc-notched-outline__trailing {\n  border-bottom: 0px !important;\n  border: 0px;\n  border-radius: 0 !important;\n}\n/*# sourceMappingURL=sponsor-list.component.css.map */"] });
var SponsorListComponent = _SponsorListComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(SponsorListComponent, { className: "SponsorListComponent", filePath: "src\\app\\features\\sponsor\\components\\sponsor-list\\sponsor-list.component.ts", lineNumber: 20 });
})();

// src/app/features/sponsor/sponsor.guard.ts
var sponsorGuard = (route, state) => {
  const windowService = inject(WindowService);
  const router = inject(Router);
  if (windowService.license.edition === 100) {
    return true;
  }
  router.navigate(["/"]);
  return false;
};

// src/app/features/sponsor/sponsor-routing.module.ts
var routes = [
  { path: "", canActivate: [sponsorGuard], component: SponsorListComponent }
];
var _SponsorRoutingModule = class _SponsorRoutingModule {
};
_SponsorRoutingModule.\u0275fac = function SponsorRoutingModule_Factory(t) {
  return new (t || _SponsorRoutingModule)();
};
_SponsorRoutingModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _SponsorRoutingModule });
_SponsorRoutingModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [RouterModule.forChild(routes)] });
var SponsorRoutingModule = _SponsorRoutingModule;

// src/app/features/sponsor/sponsor.module.ts
var _SponsorModule = class _SponsorModule {
};
_SponsorModule.\u0275fac = function SponsorModule_Factory(t) {
  return new (t || _SponsorModule)();
};
_SponsorModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _SponsorModule });
_SponsorModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [
  CommonModule,
  SponsorRoutingModule,
  FormsModule,
  MatSelectModule,
  MatIconModule,
  MatExpansionModule,
  MatCardModule,
  MatMenuModule,
  MatProgressBarModule,
  MatTooltipModule,
  MatButtonModule
] });
var SponsorModule = _SponsorModule;
export {
  SponsorModule
};
//# sourceMappingURL=chunk-RFFSR5IV.js.map
