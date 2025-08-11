import {
  SortDirection
} from "./chunk-EB7MRBEE.js";
import {
  UtilityService
} from "./chunk-PFZE6ICR.js";
import {
  MatSnackBar
} from "./chunk-TRW2IRZZ.js";
import {
  OpenSettingsService
} from "./chunk-COL4MWGT.js";
import {
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle
} from "./chunk-MFNOH2DQ.js";
import {
  DefaultValueAccessor,
  MatError,
  MatFormField,
  MatHint,
  MatIcon,
  MatInput,
  MatLabel,
  MatSuffix,
  MatTooltip,
  NgControlStatus,
  NgModel,
  RequiredValidator
} from "./chunk-OUQEPPZG.js";
import {
  AuthService,
  ChangeDetectionStrategy,
  Component,
  ContentChildren,
  DOCUMENT,
  Directive,
  ElementRef,
  HttpClient,
  HttpHeaders,
  HttpParams,
  Inject,
  Input,
  LicenseEdition,
  MatAnchor,
  MatButton,
  MatCommonModule,
  MatIconButton,
  NgIf,
  NgModule,
  Platform,
  Subject,
  Subscription,
  ViewEncapsulation$1,
  WindowService,
  setClassMetadata,
  switchMap,
  takeUntil,
  ɵsetClassDebugInfo,
  ɵɵStandaloneFeature,
  ɵɵadvance,
  ɵɵclassMap,
  ɵɵclassProp,
  ɵɵcontentQuery,
  ɵɵdefineComponent,
  ɵɵdefineDirective,
  ɵɵdefineInjectable,
  ɵɵdefineInjector,
  ɵɵdefineNgModule,
  ɵɵdirectiveInject,
  ɵɵelement,
  ɵɵelementEnd,
  ɵɵelementStart,
  ɵɵgetCurrentView,
  ɵɵinject,
  ɵɵlistener,
  ɵɵloadQuery,
  ɵɵnextContext,
  ɵɵprojection,
  ɵɵprojectionDef,
  ɵɵproperty,
  ɵɵqueryRefresh,
  ɵɵreference,
  ɵɵresetView,
  ɵɵrestoreView,
  ɵɵsanitizeUrl,
  ɵɵtemplate,
  ɵɵtext,
  ɵɵtextInterpolate,
  ɵɵtextInterpolate1,
  ɵɵtwoWayBindingSet,
  ɵɵtwoWayListener,
  ɵɵtwoWayProperty
} from "./chunk-L57OXKIA.js";

// node_modules/@angular/material/fesm2022/toolbar.mjs
var _c0 = ["*", [["mat-toolbar-row"]]];
var _c1 = ["*", "mat-toolbar-row"];
var _MatToolbarRow = class _MatToolbarRow {
};
_MatToolbarRow.\u0275fac = function MatToolbarRow_Factory(t) {
  return new (t || _MatToolbarRow)();
};
_MatToolbarRow.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatToolbarRow,
  selectors: [["mat-toolbar-row"]],
  hostAttrs: [1, "mat-toolbar-row"],
  exportAs: ["matToolbarRow"],
  standalone: true
});
var MatToolbarRow = _MatToolbarRow;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatToolbarRow, [{
    type: Directive,
    args: [{
      selector: "mat-toolbar-row",
      exportAs: "matToolbarRow",
      host: {
        "class": "mat-toolbar-row"
      },
      standalone: true
    }]
  }], null, null);
})();
var _MatToolbar = class _MatToolbar {
  constructor(_elementRef, _platform, document) {
    this._elementRef = _elementRef;
    this._platform = _platform;
    this._document = document;
  }
  ngAfterViewInit() {
    if (this._platform.isBrowser) {
      this._checkToolbarMixedModes();
      this._toolbarRows.changes.subscribe(() => this._checkToolbarMixedModes());
    }
  }
  /**
   * Throws an exception when developers are attempting to combine the different toolbar row modes.
   */
  _checkToolbarMixedModes() {
    if (this._toolbarRows.length && (typeof ngDevMode === "undefined" || ngDevMode)) {
      const isCombinedUsage = Array.from(this._elementRef.nativeElement.childNodes).filter((node) => !(node.classList && node.classList.contains("mat-toolbar-row"))).filter((node) => node.nodeType !== (this._document ? this._document.COMMENT_NODE : 8)).some((node) => !!(node.textContent && node.textContent.trim()));
      if (isCombinedUsage) {
        throwToolbarMixedModesError();
      }
    }
  }
};
_MatToolbar.\u0275fac = function MatToolbar_Factory(t) {
  return new (t || _MatToolbar)(\u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(Platform), \u0275\u0275directiveInject(DOCUMENT));
};
_MatToolbar.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatToolbar,
  selectors: [["mat-toolbar"]],
  contentQueries: function MatToolbar_ContentQueries(rf, ctx, dirIndex) {
    if (rf & 1) {
      \u0275\u0275contentQuery(dirIndex, MatToolbarRow, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._toolbarRows = _t);
    }
  },
  hostAttrs: [1, "mat-toolbar"],
  hostVars: 6,
  hostBindings: function MatToolbar_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275classMap(ctx.color ? "mat-" + ctx.color : "");
      \u0275\u0275classProp("mat-toolbar-multiple-rows", ctx._toolbarRows.length > 0)("mat-toolbar-single-row", ctx._toolbarRows.length === 0);
    }
  },
  inputs: {
    color: "color"
  },
  exportAs: ["matToolbar"],
  standalone: true,
  features: [\u0275\u0275StandaloneFeature],
  ngContentSelectors: _c1,
  decls: 2,
  vars: 0,
  template: function MatToolbar_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef(_c0);
      \u0275\u0275projection(0);
      \u0275\u0275projection(1, 1);
    }
  },
  styles: [".mat-toolbar{background:var(--mat-toolbar-container-background-color);color:var(--mat-toolbar-container-text-color)}.mat-toolbar,.mat-toolbar h1,.mat-toolbar h2,.mat-toolbar h3,.mat-toolbar h4,.mat-toolbar h5,.mat-toolbar h6{font-family:var(--mat-toolbar-title-text-font);font-size:var(--mat-toolbar-title-text-size);line-height:var(--mat-toolbar-title-text-line-height);font-weight:var(--mat-toolbar-title-text-weight);letter-spacing:var(--mat-toolbar-title-text-tracking);margin:0}.cdk-high-contrast-active .mat-toolbar{outline:solid 1px}.mat-toolbar .mat-form-field-underline,.mat-toolbar .mat-form-field-ripple,.mat-toolbar .mat-focused .mat-form-field-ripple{background-color:currentColor}.mat-toolbar .mat-form-field-label,.mat-toolbar .mat-focused .mat-form-field-label,.mat-toolbar .mat-select-value,.mat-toolbar .mat-select-arrow,.mat-toolbar .mat-form-field.mat-focused .mat-select-arrow{color:inherit}.mat-toolbar .mat-input-element{caret-color:currentColor}.mat-toolbar .mat-mdc-button-base.mat-mdc-button-base.mat-unthemed{--mdc-text-button-label-text-color:var(--mat-toolbar-container-text-color);--mdc-outlined-button-label-text-color:var(--mat-toolbar-container-text-color)}.mat-toolbar-row,.mat-toolbar-single-row{display:flex;box-sizing:border-box;padding:0 16px;width:100%;flex-direction:row;align-items:center;white-space:nowrap;height:var(--mat-toolbar-standard-height)}@media(max-width: 599px){.mat-toolbar-row,.mat-toolbar-single-row{height:var(--mat-toolbar-mobile-height)}}.mat-toolbar-multiple-rows{display:flex;box-sizing:border-box;flex-direction:column;width:100%;min-height:var(--mat-toolbar-standard-height)}@media(max-width: 599px){.mat-toolbar-multiple-rows{min-height:var(--mat-toolbar-mobile-height)}}"],
  encapsulation: 2,
  changeDetection: 0
});
var MatToolbar = _MatToolbar;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatToolbar, [{
    type: Component,
    args: [{
      selector: "mat-toolbar",
      exportAs: "matToolbar",
      host: {
        "class": "mat-toolbar",
        "[class]": 'color ? "mat-" + color : ""',
        "[class.mat-toolbar-multiple-rows]": "_toolbarRows.length > 0",
        "[class.mat-toolbar-single-row]": "_toolbarRows.length === 0"
      },
      changeDetection: ChangeDetectionStrategy.OnPush,
      encapsulation: ViewEncapsulation$1.None,
      standalone: true,
      template: '<ng-content></ng-content>\n<ng-content select="mat-toolbar-row"></ng-content>\n',
      styles: [".mat-toolbar{background:var(--mat-toolbar-container-background-color);color:var(--mat-toolbar-container-text-color)}.mat-toolbar,.mat-toolbar h1,.mat-toolbar h2,.mat-toolbar h3,.mat-toolbar h4,.mat-toolbar h5,.mat-toolbar h6{font-family:var(--mat-toolbar-title-text-font);font-size:var(--mat-toolbar-title-text-size);line-height:var(--mat-toolbar-title-text-line-height);font-weight:var(--mat-toolbar-title-text-weight);letter-spacing:var(--mat-toolbar-title-text-tracking);margin:0}.cdk-high-contrast-active .mat-toolbar{outline:solid 1px}.mat-toolbar .mat-form-field-underline,.mat-toolbar .mat-form-field-ripple,.mat-toolbar .mat-focused .mat-form-field-ripple{background-color:currentColor}.mat-toolbar .mat-form-field-label,.mat-toolbar .mat-focused .mat-form-field-label,.mat-toolbar .mat-select-value,.mat-toolbar .mat-select-arrow,.mat-toolbar .mat-form-field.mat-focused .mat-select-arrow{color:inherit}.mat-toolbar .mat-input-element{caret-color:currentColor}.mat-toolbar .mat-mdc-button-base.mat-mdc-button-base.mat-unthemed{--mdc-text-button-label-text-color:var(--mat-toolbar-container-text-color);--mdc-outlined-button-label-text-color:var(--mat-toolbar-container-text-color)}.mat-toolbar-row,.mat-toolbar-single-row{display:flex;box-sizing:border-box;padding:0 16px;width:100%;flex-direction:row;align-items:center;white-space:nowrap;height:var(--mat-toolbar-standard-height)}@media(max-width: 599px){.mat-toolbar-row,.mat-toolbar-single-row{height:var(--mat-toolbar-mobile-height)}}.mat-toolbar-multiple-rows{display:flex;box-sizing:border-box;flex-direction:column;width:100%;min-height:var(--mat-toolbar-standard-height)}@media(max-width: 599px){.mat-toolbar-multiple-rows{min-height:var(--mat-toolbar-mobile-height)}}"]
    }]
  }], () => [{
    type: ElementRef
  }, {
    type: Platform
  }, {
    type: void 0,
    decorators: [{
      type: Inject,
      args: [DOCUMENT]
    }]
  }], {
    color: [{
      type: Input
    }],
    _toolbarRows: [{
      type: ContentChildren,
      args: [MatToolbarRow, {
        descendants: true
      }]
    }]
  });
})();
function throwToolbarMixedModesError() {
  throw Error("MatToolbar: Attempting to combine different toolbar modes. Either specify multiple `<mat-toolbar-row>` elements explicitly or just place content inside of a `<mat-toolbar>` for a single row.");
}
var _MatToolbarModule = class _MatToolbarModule {
};
_MatToolbarModule.\u0275fac = function MatToolbarModule_Factory(t) {
  return new (t || _MatToolbarModule)();
};
_MatToolbarModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({
  type: _MatToolbarModule
});
_MatToolbarModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({
  imports: [MatCommonModule, MatCommonModule]
});
var MatToolbarModule = _MatToolbarModule;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatToolbarModule, [{
    type: NgModule,
    args: [{
      imports: [MatCommonModule, MatToolbar, MatToolbarRow],
      exports: [MatToolbar, MatToolbarRow, MatCommonModule]
    }]
  }], null, null);
})();

// src/app/features/licenses/services/licenses.service.ts
var _LicensesService = class _LicensesService {
  constructor(httpClient, authService, windowService) {
    this.httpClient = httpClient;
    this.authService = authService;
    this.headers = new HttpHeaders();
    this.destroy$ = new Subject();
    this.route = windowService.controller.route;
    this.authService.isAuthenticated$.pipe(takeUntil(this.destroy$)).subscribe((isAuthenticated) => {
      this.headers = isAuthenticated ? new HttpHeaders({ "Authorization": `${this.authService.token}` }) : new HttpHeaders();
    });
  }
  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
  getPaginatedLicenses(request) {
    let url = this.route + "/v1/licenses/paginated";
    let params = new HttpParams();
    if (request.pageIndex) {
      params = params.append("page", request.pageIndex);
    }
    if (request.pageSize) {
      params = params.append("size", request.pageSize);
    }
    if (request.searchTerm) {
      params = params.append("searchTerm", request.searchTerm);
    }
    if (request.searchBy) {
      params = params.append("searchBy", request.searchBy);
    }
    if (request.sortBy) {
      params = params.append("sortBy", request.sortBy);
      if (request.sortDirection === SortDirection.Desc) {
        params = params.append("sortDirection", request.sortDirection);
      }
    }
    const queryParams = params.toString();
    url += queryParams ? "?" + queryParams : "";
    return this.httpClient.get(url, { headers: this.headers });
  }
  getCurrentLicense() {
    let url = this.route + "/v1/licenses/current";
    return this.httpClient.get(url, { headers: this.headers });
  }
  saveLicense(request) {
    const url = this.route + "/v1/licenses";
    return this.httpClient.post(url, `"${request.licenseKey}"`, { headers: this.headers.set("Content-Type", "application/json") });
  }
  deleteLicense(referenceId) {
    const url = this.route + "/v1/licenses/" + encodeURIComponent(referenceId);
    return this.httpClient.delete(url, { headers: this.headers });
  }
  getLicenseUpdateMessage(initialLicense, currentLicense) {
    let message;
    let duration;
    if (initialLicense.referenceId === currentLicense.referenceId) {
      message = `A new license has been registered, but your current license remains unchanged because it has a higher tier or a later expiration date.`;
      duration = 8e3;
    } else if (initialLicense.edition === currentLicense.edition) {
      message = "The license has been updated!";
      duration = 3500;
    } else {
      message = `The license has been ${currentLicense.edition > initialLicense.edition ? "upgraded" : "downgraded"} to ${LicenseEdition[currentLicense.edition]} Edition!`;
      duration = 5250;
    }
    return {
      message,
      duration
    };
  }
};
_LicensesService.\u0275fac = function LicensesService_Factory(t) {
  return new (t || _LicensesService)(\u0275\u0275inject(HttpClient), \u0275\u0275inject(AuthService), \u0275\u0275inject(WindowService));
};
_LicensesService.\u0275prov = /* @__PURE__ */ \u0275\u0275defineInjectable({ token: _LicensesService, factory: _LicensesService.\u0275fac, providedIn: "root" });
var LicensesService = _LicensesService;

// src/app/features/licenses/license-upgrade/license-upgrade.component.ts
function LicenseUpgradeComponent_div_0_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "div", 14)(1, "div", 15);
    \u0275\u0275element(2, "img", 16);
    \u0275\u0275elementEnd();
    \u0275\u0275element(3, "div", 17);
    \u0275\u0275elementEnd();
  }
}
function LicenseUpgradeComponent_mat_error_24_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-error");
    \u0275\u0275text(1, "License key is required");
    \u0275\u0275elementEnd();
  }
}
function LicenseUpgradeComponent_a_26_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "a", 18)(1, "span");
    \u0275\u0275text(2, "Get a License");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r2 = \u0275\u0275nextContext();
    \u0275\u0275property("href", ctx_r2.licenseLink.url, \u0275\u0275sanitizeUrl);
  }
}
var _LicenseUpgradeComponent = class _LicenseUpgradeComponent {
  constructor(licensesService, openSettingsService, utilityService, windowService, dialogRef, snackBar) {
    this.licensesService = licensesService;
    this.openSettingsService = openSettingsService;
    this.utilityService = utilityService;
    this.windowService = windowService;
    this.dialogRef = dialogRef;
    this.snackBar = snackBar;
    this.hideLicenseKey = true;
    this.subscriptions = new Subscription();
    this.licenseLink = { url: "", isActive: false };
    this.isLoading = false;
    this.actionName = windowService.license.edition === LicenseEdition.Enterprise ? "Re-new" : "Upgrade";
  }
  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
  ngOnInit() {
    const linkSubscription = this.openSettingsService.getLinks().subscribe((response) => {
      const licenseLink = response["license"];
      if (licenseLink) {
        this.licenseLink.url = licenseLink.url;
        this.licenseLink.isActive = licenseLink.isActive;
      }
    });
    this.subscriptions.add(linkSubscription);
  }
  upgradeLicense(licenseKey) {
    if (!licenseKey) {
      return;
    }
    this.isLoading = true;
    const subscription = this.licensesService.saveLicense({ licenseKey }).pipe(switchMap(() => this.licensesService.getCurrentLicense())).subscribe({
      next: (response) => {
        const currentLicense = response.data;
        if (!currentLicense) {
          this.isLoading = false;
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
        this.isLoading = false;
        this.dialogRef.close(true);
      },
      error: (err) => {
        const response = err.error;
        if (response && response.errors) {
          this.utilityService.error(response.errors, 3500);
        } else {
          this.utilityService.simpleError(err.message, 2250);
        }
        this.isLoading = false;
      }
    });
    this.subscriptions.add(subscription);
  }
  upload(event) {
    this.utilityService.upload(event.target.files[0]).then((content) => {
      const licenseKey = content.trim();
      this.upgradeLicense(licenseKey);
    }).catch((error) => {
      this.snackBar.open(`Error occurred while uploading file. Error: ${error}`, "Close", {
        horizontalPosition: "right",
        verticalPosition: "top",
        duration: 8e3
      });
    });
  }
  toggleLicenseKeyVisibility() {
    this.hideLicenseKey = !this.hideLicenseKey;
  }
};
_LicenseUpgradeComponent.\u0275fac = function LicenseUpgradeComponent_Factory(t) {
  return new (t || _LicenseUpgradeComponent)(\u0275\u0275directiveInject(LicensesService), \u0275\u0275directiveInject(OpenSettingsService), \u0275\u0275directiveInject(UtilityService), \u0275\u0275directiveInject(WindowService), \u0275\u0275directiveInject(MatDialogRef), \u0275\u0275directiveInject(MatSnackBar));
};
_LicenseUpgradeComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _LicenseUpgradeComponent, selectors: [["ng-component"]], decls: 29, vars: 9, consts: [["licenseInput", "ngModel"], ["fileInput", ""], ["class", "loading-container", 4, "ngIf"], ["mat-dialog-title", ""], ["mat-icon-button", "", "mat-dialog-close", "", "matTooltip", "Close", "matTooltipPosition", "above", 1, "position-absolute", "r-0", "t-0"], ["appearance", "outline", 1, "full-width"], ["matInput", "", "required", "", 3, "ngModelChange", "type", "ngModel"], ["mat-icon-button", "", "matSuffix", "", "matTooltip", "Upload", "color", "primary", 3, "click"], ["type", "file", "accept", ".txt,.key", 1, "d-none", 3, "change"], ["mat-icon-button", "", "matSuffix", "", 3, "click"], [4, "ngIf"], ["align", "end"], ["mat-button", "", "target", "_blank", 3, "href", 4, "ngIf"], ["type", "submit", "mat-flat-button", "", "color", "primary", 3, "click", "disabled"], [1, "loading-container"], [1, "mat-bg-primary", "position-absolute", "rounded-circle", "app-icon-animation"], [1, "app-icon", "bg-white"], [1, "loading-spinner"], ["mat-button", "", "target", "_blank", 3, "href"]], template: function LicenseUpgradeComponent_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275template(0, LicenseUpgradeComponent_div_0_Template, 4, 0, "div", 2);
    \u0275\u0275elementStart(1, "h2", 3);
    \u0275\u0275text(2);
    \u0275\u0275elementStart(3, "button", 4)(4, "mat-icon");
    \u0275\u0275text(5, "close");
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(6, "mat-dialog-content")(7, "p");
    \u0275\u0275text(8, "Please enter your license below:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(9, "mat-form-field", 5)(10, "mat-label");
    \u0275\u0275text(11, "License Key");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(12, "input", 6, 0);
    \u0275\u0275twoWayListener("ngModelChange", function LicenseUpgradeComponent_Template_input_ngModelChange_12_listener($event) {
      \u0275\u0275restoreView(_r1);
      \u0275\u0275twoWayBindingSet(ctx.licenseKey, $event) || (ctx.licenseKey = $event);
      return \u0275\u0275resetView($event);
    });
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(14, "button", 7);
    \u0275\u0275listener("click", function LicenseUpgradeComponent_Template_button_click_14_listener() {
      \u0275\u0275restoreView(_r1);
      const fileInput_r2 = \u0275\u0275reference(18);
      return \u0275\u0275resetView(fileInput_r2.click());
    });
    \u0275\u0275elementStart(15, "mat-icon");
    \u0275\u0275text(16, "upload");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(17, "input", 8, 1);
    \u0275\u0275listener("change", function LicenseUpgradeComponent_Template_input_change_17_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.upload($event));
    });
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(19, "button", 9);
    \u0275\u0275listener("click", function LicenseUpgradeComponent_Template_button_click_19_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.toggleLicenseKeyVisibility());
    });
    \u0275\u0275elementStart(20, "mat-icon");
    \u0275\u0275text(21);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(22, "mat-hint");
    \u0275\u0275text(23, "A restart may be required for full changes to take effect.");
    \u0275\u0275elementEnd();
    \u0275\u0275template(24, LicenseUpgradeComponent_mat_error_24_Template, 2, 0, "mat-error", 10);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(25, "mat-dialog-actions", 11);
    \u0275\u0275template(26, LicenseUpgradeComponent_a_26_Template, 3, 1, "a", 12);
    \u0275\u0275elementStart(27, "button", 13);
    \u0275\u0275listener("click", function LicenseUpgradeComponent_Template_button_click_27_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.upgradeLicense(ctx.licenseKey));
    });
    \u0275\u0275text(28);
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const licenseInput_r4 = \u0275\u0275reference(13);
    \u0275\u0275property("ngIf", ctx.isLoading);
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate1(" ", ctx.actionName, " OpenSettings ");
    \u0275\u0275advance(10);
    \u0275\u0275property("type", ctx.hideLicenseKey ? "password" : "text");
    \u0275\u0275twoWayProperty("ngModel", ctx.licenseKey);
    \u0275\u0275advance(9);
    \u0275\u0275textInterpolate(ctx.hideLicenseKey ? "visibility_off" : "visibility");
    \u0275\u0275advance(3);
    \u0275\u0275property("ngIf", licenseInput_r4.invalid);
    \u0275\u0275advance(2);
    \u0275\u0275property("ngIf", ctx.licenseLink.isActive && ctx.licenseLink.url);
    \u0275\u0275advance();
    \u0275\u0275property("disabled", !ctx.licenseKey);
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(ctx.actionName);
  }
}, dependencies: [NgIf, DefaultValueAccessor, NgControlStatus, RequiredValidator, NgModel, MatDialogClose, MatDialogTitle, MatDialogActions, MatDialogContent, MatAnchor, MatButton, MatIconButton, MatIcon, MatTooltip, MatFormField, MatLabel, MatHint, MatError, MatSuffix, MatInput], encapsulation: 2 });
var LicenseUpgradeComponent = _LicenseUpgradeComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(LicenseUpgradeComponent, { className: "LicenseUpgradeComponent", filePath: "src\\app\\features\\licenses\\license-upgrade\\license-upgrade.component.ts", lineNumber: 15 });
})();

export {
  LicensesService,
  LicenseUpgradeComponent,
  MatToolbar,
  MatToolbarModule
};
//# sourceMappingURL=chunk-5F4UL5JR.js.map
