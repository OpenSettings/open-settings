import {
  LicenseUpgradeComponent,
  LicensesService
} from "./chunk-6EGXYXAX.js";
import {
  MatCell,
  MatCellDef,
  MatColumnDef,
  MatHeaderCell,
  MatHeaderCellDef,
  MatRow,
  MatRowDef,
  MatTable,
  MatTableModule
} from "./chunk-BTPWLNSG.js";
import "./chunk-EB7MRBEE.js";
import "./chunk-4H4XXYOP.js";
import {
  MatSnackBar
} from "./chunk-JQUQ3G7S.js";
import {
  OpenSettingsService
} from "./chunk-I6EEGYC4.js";
import {
  ConfirmationDialogComponent,
  MatDialog
} from "./chunk-HQT7NEGY.js";
import {
  MatCard,
  MatCardActions,
  MatCardContent,
  MatCardHeader,
  MatCardModule,
  MatCardTitle,
  MatIcon,
  MatIconModule,
  MatTooltip,
  MatTooltipModule
} from "./chunk-AXECPBMH.js";
import {
  CommonModule,
  DatePipe,
  MatAnchor,
  MatButton,
  MatButtonModule,
  NgIf,
  RouterModule,
  Subscription,
  WindowService,
  filter,
  switchMap,
  ɵsetClassDebugInfo,
  ɵɵadvance,
  ɵɵdefineComponent,
  ɵɵdefineInjector,
  ɵɵdefineNgModule,
  ɵɵdirectiveInject,
  ɵɵelement,
  ɵɵelementContainerEnd,
  ɵɵelementContainerStart,
  ɵɵelementEnd,
  ɵɵelementStart,
  ɵɵgetCurrentView,
  ɵɵlistener,
  ɵɵnextContext,
  ɵɵproperty,
  ɵɵresetView,
  ɵɵrestoreView,
  ɵɵsanitizeUrl,
  ɵɵtemplate,
  ɵɵtext,
  ɵɵtextInterpolate
} from "./chunk-SUR7UARE.js";

// src/app/features/about/about.component.ts
function AboutComponent_th_11_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "th", 20);
    \u0275\u0275text(1, "Attribute");
    \u0275\u0275elementEnd();
  }
}
function AboutComponent_td_12_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "td", 21);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const element_r1 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(element_r1.key);
  }
}
function AboutComponent_th_14_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "th", 20);
    \u0275\u0275text(1, "Value");
    \u0275\u0275elementEnd();
  }
}
function AboutComponent_td_15_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "td", 22);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const element_r2 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(element_r2.value);
  }
}
function AboutComponent_tr_16_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "tr", 23);
  }
}
function AboutComponent_mat_card_actions_17_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-card-actions", 17)(1, "a", 24);
    \u0275\u0275text(2, "View Release Notes");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r2 = \u0275\u0275nextContext();
    \u0275\u0275advance();
    \u0275\u0275property("href", ctx_r2.viewReleaseNotes(ctx_r2.packVersion), \u0275\u0275sanitizeUrl);
  }
}
function AboutComponent_mat_card_18_th_7_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "th", 20);
    \u0275\u0275text(1, "Attribute");
    \u0275\u0275elementEnd();
  }
}
function AboutComponent_mat_card_18_td_8_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "td", 21);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const element_r4 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(element_r4.key);
  }
}
function AboutComponent_mat_card_18_th_10_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "th", 20);
    \u0275\u0275text(1, "Value");
    \u0275\u0275elementEnd();
  }
}
function AboutComponent_mat_card_18_td_11_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "td", 22);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const element_r5 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(element_r5.value);
  }
}
function AboutComponent_mat_card_18_tr_12_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "tr", 23);
  }
}
function AboutComponent_mat_card_18_mat_card_actions_13_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-card-actions", 17)(1, "a", 24);
    \u0275\u0275text(2, "View Release Notes");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r2 = \u0275\u0275nextContext(2);
    \u0275\u0275advance();
    \u0275\u0275property("href", ctx_r2.viewReleaseNotes(ctx_r2.providerInfo.packVersion), \u0275\u0275sanitizeUrl);
  }
}
function AboutComponent_mat_card_18_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-card", 13)(1, "mat-card-header", 2)(2, "mat-card-title", 3);
    \u0275\u0275text(3, "Provider Information");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(4, "mat-card-content")(5, "table", 4);
    \u0275\u0275elementContainerStart(6, 5);
    \u0275\u0275template(7, AboutComponent_mat_card_18_th_7_Template, 2, 0, "th", 6)(8, AboutComponent_mat_card_18_td_8_Template, 2, 1, "td", 7);
    \u0275\u0275elementContainerEnd();
    \u0275\u0275elementContainerStart(9, 8);
    \u0275\u0275template(10, AboutComponent_mat_card_18_th_10_Template, 2, 0, "th", 6)(11, AboutComponent_mat_card_18_td_11_Template, 2, 1, "td", 9);
    \u0275\u0275elementContainerEnd();
    \u0275\u0275template(12, AboutComponent_mat_card_18_tr_12_Template, 1, 0, "tr", 10);
    \u0275\u0275elementEnd()();
    \u0275\u0275template(13, AboutComponent_mat_card_18_mat_card_actions_13_Template, 3, 1, "mat-card-actions", 11);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r2 = \u0275\u0275nextContext();
    \u0275\u0275advance(5);
    \u0275\u0275property("dataSource", ctx_r2.providerDataSource);
    \u0275\u0275advance(7);
    \u0275\u0275property("matRowDefColumns", ctx_r2.displayedColumns);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx_r2.releaseNotes.isActive && ctx_r2.releaseNotes.url);
  }
}
function AboutComponent_th_29_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "th", 20);
    \u0275\u0275text(1, "Attribute");
    \u0275\u0275elementEnd();
  }
}
function AboutComponent_td_30_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "td", 21);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const element_r6 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(element_r6.key);
  }
}
function AboutComponent_th_32_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "th", 20);
    \u0275\u0275text(1, "Value");
    \u0275\u0275elementEnd();
  }
}
function AboutComponent_td_33_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "td", 22);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const element_r7 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(element_r7.value);
  }
}
function AboutComponent_tr_34_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "tr", 23);
  }
}
function AboutComponent_button_38_Template(rf, ctx) {
  if (rf & 1) {
    const _r8 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 25);
    \u0275\u0275listener("click", function AboutComponent_button_38_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r8);
      const ctx_r2 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r2.deleteLicense());
    });
    \u0275\u0275text(1, "Delete");
    \u0275\u0275elementEnd();
  }
}
var _AboutComponent = class _AboutComponent {
  constructor(windowService, openSettingsService, licensesService, datePipe, dialog, snackBar) {
    this.windowService = windowService;
    this.openSettingsService = openSettingsService;
    this.licensesService = licensesService;
    this.datePipe = datePipe;
    this.dialog = dialog;
    this.snackBar = snackBar;
    this.isProvider = false;
    this.releaseNotes = { url: "", isActive: false };
    this.displayedColumns = ["key", "value"];
    this.appDataSource = [];
    this.providerDataSource = [];
    this.licenseDataSource = [];
    this.subscriptions = new Subscription();
  }
  ngOnInit() {
    this.isProvider = this.windowService.isProvider;
    this.providerInfo = this.windowService.providerInfo;
    this.packVersion = this.windowService.packVersion;
    this.version = this.windowService.version;
    this.clientName = this.windowService.clientName;
    this.appDataSource = [
      { key: "Name", value: this.clientName },
      { key: "Version", value: "v" + this.version },
      { key: "OpenSettings Pack Version", value: "v" + this.packVersion }
    ];
    this.providerDataSource = [
      { key: "Name", value: this.providerInfo.clientName },
      { key: "Version", value: "v" + this.providerInfo.version },
      { key: "OpenSettings Pack Version", value: "v" + this.providerInfo.packVersion }
    ];
    const licenseSubscription = this.windowService.license$.subscribe((license) => {
      this.license = license;
      this.initializeLicenseDataSource();
    });
    this.subscriptions.add(licenseSubscription);
    const subscription = this.openSettingsService.getLinks().subscribe((response) => {
      const releaseNotes = response["releaseNotes"];
      if (releaseNotes) {
        this.releaseNotes.url = releaseNotes.url;
        this.releaseNotes.isActive = releaseNotes.isActive;
      }
    });
    this.subscriptions.add(subscription);
  }
  initializeLicenseDataSource() {
    this.licenseDataSource = [];
    if (!this.license) {
      return;
    }
    if (this.license.holder) {
      this.licenseDataSource.push({ key: "Holder", value: this.license.holder });
    }
    if (this.license.referenceId) {
      this.licenseDataSource.push({ key: "Reference Id", value: this.license.referenceId });
    }
    if (this.license.edition) {
      this.licenseDataSource.push({ key: "Edition", value: this.license.editionStringRepresentation });
    }
    if (this.license.issuedAt) {
      this.licenseDataSource.push({ key: "Activated On", value: this.datePipe.transform(this.license.issuedAt, "dd-MM-yyyy HH:mm") ?? "" });
    }
    if (this.license.expiryDate) {
      this.licenseDataSource.push({ key: "Expiry Date", value: this.datePipe.transform(this.license.expiryDate, "dd-MM-yyyy HH:mm") ?? "" });
    }
    this.licenseDataSource.push({ key: "Status", value: this.license.isExpired ? "Inactive" : "Active" });
  }
  viewReleaseNotes(version) {
    if (version) {
      return this.releaseNotes.url.replace("%(Version)", version);
    }
    return "";
  }
  upgradeLicense() {
    this.dialog.open(LicenseUpgradeComponent, {
      width: "500px",
      height: "265px",
      minWidth: "inherit",
      maxWidth: "inherit",
      autoFocus: false
    });
  }
  deleteLicense() {
    const referenceId = this.license?.referenceId;
    if (!referenceId) {
      return;
    }
    const title = "Confirm delete";
    const message = `Are you sure you want to delete the '${referenceId}' license? This action cannot be undone.`;
    const confirmationDialogComponentModel = {
      title,
      message,
      requireConfirmation: true
    };
    const subscription = this.dialog.open(ConfirmationDialogComponent, {
      width: "500px",
      data: confirmationDialogComponentModel
    }).afterClosed().pipe(filter((result) => !!result), switchMap(() => this.licensesService.deleteLicense(referenceId)), switchMap(() => this.licensesService.getCurrentLicense())).subscribe({
      next: (response) => {
        const currentLicense = response.data;
        if (!currentLicense) {
          return;
        }
        const initialLicense = this.windowService.license;
        const licenseUpdateMessage = this.licensesService.getLicenseUpdateMessage(initialLicense, currentLicense);
        this.windowService.updateLicense(currentLicense);
        this.snackBar.open(licenseUpdateMessage.message, "Close", {
          horizontalPosition: "right",
          verticalPosition: "top",
          duration: licenseUpdateMessage.duration
        });
      }
    });
    this.subscriptions.add(subscription);
  }
};
_AboutComponent.\u0275fac = function AboutComponent_Factory(t) {
  return new (t || _AboutComponent)(\u0275\u0275directiveInject(WindowService), \u0275\u0275directiveInject(OpenSettingsService), \u0275\u0275directiveInject(LicensesService), \u0275\u0275directiveInject(DatePipe), \u0275\u0275directiveInject(MatDialog), \u0275\u0275directiveInject(MatSnackBar));
};
_AboutComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _AboutComponent, selectors: [["ng-component"]], decls: 39, vars: 8, consts: [[1, "px-3"], [1, "title", "mb-3"], [1, "mb-2"], [1, "card-title"], ["mat-table", "", 3, "dataSource"], ["matColumnDef", "key"], ["mat-header-cell", "", 4, "matHeaderCellDef"], ["mat-cell", "", "class", "font-weight-500 w-50", 4, "matCellDef"], ["matColumnDef", "value"], ["mat-cell", "", 4, "matCellDef"], ["mat-row", "", 4, "matRowDef", "matRowDefColumns"], ["align", "end", 4, "ngIf"], ["class", "mt-3", 4, "ngIf"], [1, "mt-3"], [1, "card-title", "w-100", "d-flex"], [1, "spacer"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "It shows the current license. Only active license will be shown here. If multiple licenses added, the highest edition with the longest expiry date takes precedence.", "matTooltipPosition", "below"], ["align", "end"], ["mat-button", "", "color", "primary mr-3", 3, "click"], ["mat-button", "", "color", "warn", 3, "click", 4, "ngIf"], ["mat-header-cell", ""], ["mat-cell", "", 1, "font-weight-500", "w-50"], ["mat-cell", ""], ["mat-row", ""], ["mat-button", "", "color", "primary", "target", "_blank", 3, "href"], ["mat-button", "", "color", "warn", 3, "click"]], template: function AboutComponent_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "div", 0)(1, "div", 1)(2, "h1");
    \u0275\u0275text(3, "About");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(4, "mat-card")(5, "mat-card-header", 2)(6, "mat-card-title", 3);
    \u0275\u0275text(7, "Application Information");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(8, "mat-card-content")(9, "table", 4);
    \u0275\u0275elementContainerStart(10, 5);
    \u0275\u0275template(11, AboutComponent_th_11_Template, 2, 0, "th", 6)(12, AboutComponent_td_12_Template, 2, 1, "td", 7);
    \u0275\u0275elementContainerEnd();
    \u0275\u0275elementContainerStart(13, 8);
    \u0275\u0275template(14, AboutComponent_th_14_Template, 2, 0, "th", 6)(15, AboutComponent_td_15_Template, 2, 1, "td", 9);
    \u0275\u0275elementContainerEnd();
    \u0275\u0275template(16, AboutComponent_tr_16_Template, 1, 0, "tr", 10);
    \u0275\u0275elementEnd()();
    \u0275\u0275template(17, AboutComponent_mat_card_actions_17_Template, 3, 1, "mat-card-actions", 11);
    \u0275\u0275elementEnd();
    \u0275\u0275template(18, AboutComponent_mat_card_18_Template, 14, 3, "mat-card", 12);
    \u0275\u0275elementStart(19, "mat-card", 13)(20, "mat-card-header", 2)(21, "mat-card-title", 14)(22, "span");
    \u0275\u0275text(23, "License Information");
    \u0275\u0275elementEnd();
    \u0275\u0275element(24, "span", 15)(25, "mat-icon", 16);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(26, "mat-card-content")(27, "table", 4);
    \u0275\u0275elementContainerStart(28, 5);
    \u0275\u0275template(29, AboutComponent_th_29_Template, 2, 0, "th", 6)(30, AboutComponent_td_30_Template, 2, 1, "td", 7);
    \u0275\u0275elementContainerEnd();
    \u0275\u0275elementContainerStart(31, 8);
    \u0275\u0275template(32, AboutComponent_th_32_Template, 2, 0, "th", 6)(33, AboutComponent_td_33_Template, 2, 1, "td", 9);
    \u0275\u0275elementContainerEnd();
    \u0275\u0275template(34, AboutComponent_tr_34_Template, 1, 0, "tr", 10);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(35, "mat-card-actions", 17)(36, "button", 18);
    \u0275\u0275listener("click", function AboutComponent_Template_button_click_36_listener() {
      return ctx.upgradeLicense();
    });
    \u0275\u0275text(37);
    \u0275\u0275elementEnd();
    \u0275\u0275template(38, AboutComponent_button_38_Template, 2, 0, "button", 19);
    \u0275\u0275elementEnd()()();
  }
  if (rf & 2) {
    \u0275\u0275advance(9);
    \u0275\u0275property("dataSource", ctx.appDataSource);
    \u0275\u0275advance(7);
    \u0275\u0275property("matRowDefColumns", ctx.displayedColumns);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.releaseNotes.isActive && ctx.releaseNotes.url);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", !ctx.isProvider);
    \u0275\u0275advance(9);
    \u0275\u0275property("dataSource", ctx.licenseDataSource);
    \u0275\u0275advance(7);
    \u0275\u0275property("matRowDefColumns", ctx.displayedColumns);
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate((ctx.license == null ? null : ctx.license.edition) === 500 ? "Re-new" : "Upgrade");
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.license == null ? null : ctx.license.referenceId);
  }
}, dependencies: [NgIf, MatCard, MatCardActions, MatCardContent, MatCardHeader, MatCardTitle, MatAnchor, MatButton, MatTable, MatHeaderCellDef, MatColumnDef, MatCellDef, MatRowDef, MatHeaderCell, MatCell, MatRow, MatIcon, MatTooltip], styles: ["\n\n.card-title[_ngcontent-%COMP%] {\n  font-size: var(--mat-expansion-header-text-size);\n}\n  .mat-mdc-card-header .mat-mdc-card-header-text {\n  width: 100% !important;\n}\n/*# sourceMappingURL=about.component.css.map */"] });
var AboutComponent = _AboutComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(AboutComponent, { className: "AboutComponent", filePath: "src\\app\\features\\about\\about.component.ts", lineNumber: 17 });
})();

// src/app/features/about/about-routing.module.ts
var routes = [
  { path: "", component: AboutComponent }
];
var _AboutRoutingModule = class _AboutRoutingModule {
};
_AboutRoutingModule.\u0275fac = function AboutRoutingModule_Factory(t) {
  return new (t || _AboutRoutingModule)();
};
_AboutRoutingModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _AboutRoutingModule });
_AboutRoutingModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [RouterModule.forChild(routes), RouterModule] });
var AboutRoutingModule = _AboutRoutingModule;

// src/app/features/about/about.module.ts
var _AboutModule = class _AboutModule {
};
_AboutModule.\u0275fac = function AboutModule_Factory(t) {
  return new (t || _AboutModule)();
};
_AboutModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _AboutModule });
_AboutModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ providers: [DatePipe], imports: [
  CommonModule,
  AboutRoutingModule,
  MatCardModule,
  MatButtonModule,
  MatTableModule,
  MatIconModule,
  MatTooltipModule
] });
var AboutModule = _AboutModule;
export {
  AboutModule
};
//# sourceMappingURL=chunk-RVIVUZDJ.js.map
