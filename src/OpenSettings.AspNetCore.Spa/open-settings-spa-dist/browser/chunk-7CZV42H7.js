import {
  CustomValidators
} from "./chunk-QG7R5YN6.js";
import {
  MatDivider,
  MatDividerModule
} from "./chunk-TDUSDNS5.js";
import {
  MatSnackBar
} from "./chunk-JQUQ3G7S.js";
import {
  DefaultValueAccessor,
  FormBuilder,
  FormControlName,
  FormGroupDirective,
  MatCard,
  MatCardContent,
  MatCardModule,
  MatCardTitle,
  MatError,
  MatFormField,
  MatFormFieldModule,
  MatIcon,
  MatIconModule,
  MatInput,
  MatInputModule,
  MatLabel,
  MatSuffix,
  MatTooltipModule,
  NgControlStatus,
  NgControlStatusGroup,
  ReactiveFormsModule,
  Validators,
  ɵNgNoValidate
} from "./chunk-AXECPBMH.js";
import {
  AuthService,
  CommonModule,
  MatButton,
  MatButtonModule,
  MatIconButton,
  NgIf,
  Router,
  RouterModule,
  Subscription,
  UserPreferencesService,
  WindowService,
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
  ɵɵnextContext,
  ɵɵproperty,
  ɵɵreference,
  ɵɵresetView,
  ɵɵrestoreView,
  ɵɵtemplate,
  ɵɵtemplateRefExtractor,
  ɵɵtext,
  ɵɵtextInterpolate,
  ɵɵtextInterpolate1
} from "./chunk-SUR7UARE.js";

// src/app/features/login/login.component.ts
function LoginComponent_div_5_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div", 6)(1, "button", 7);
    \u0275\u0275listener("click", function LoginComponent_div_5_Template_button_click_1_listener() {
      \u0275\u0275restoreView(_r1);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.selectLogin("basic"));
    });
    \u0275\u0275elementStart(2, "mat-icon");
    \u0275\u0275text(3, "vpn_key");
    \u0275\u0275elementEnd();
    \u0275\u0275text(4, "Basic");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(5, "button", 8);
    \u0275\u0275listener("click", function LoginComponent_div_5_Template_button_click_5_listener() {
      \u0275\u0275restoreView(_r1);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.handleOauth());
    });
    \u0275\u0275elementStart(6, "mat-icon");
    \u0275\u0275text(7, "enhanced_encryption");
    \u0275\u0275elementEnd();
    \u0275\u0275text(8, "OAuth");
    \u0275\u0275elementEnd()();
  }
}
function LoginComponent_ng_template_8_mat_card_content_0_mat_error_6_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-error", 19);
    \u0275\u0275text(1, "Invalid GUID.");
    \u0275\u0275elementEnd();
  }
}
function LoginComponent_ng_template_8_mat_card_content_0_mat_error_14_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-error");
    \u0275\u0275text(1, "Invalid GUID.");
    \u0275\u0275elementEnd();
  }
}
function LoginComponent_ng_template_8_mat_card_content_0_button_17_Template(rf, ctx) {
  if (rf & 1) {
    const _r4 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 20);
    \u0275\u0275listener("click", function LoginComponent_ng_template_8_mat_card_content_0_button_17_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r4);
      const ctx_r1 = \u0275\u0275nextContext(3);
      return \u0275\u0275resetView(ctx_r1.reset());
    });
    \u0275\u0275text(1, "Back");
    \u0275\u0275elementEnd();
  }
}
function LoginComponent_ng_template_8_mat_card_content_0_Template(rf, ctx) {
  if (rf & 1) {
    const _r3 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "mat-card-content", 6)(1, "form", 10);
    \u0275\u0275listener("ngSubmit", function LoginComponent_ng_template_8_mat_card_content_0_Template_form_ngSubmit_1_listener() {
      \u0275\u0275restoreView(_r3);
      const ctx_r1 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r1.onSubmit());
    });
    \u0275\u0275elementStart(2, "mat-form-field", 11)(3, "mat-label");
    \u0275\u0275text(4, "Client Id:");
    \u0275\u0275elementEnd();
    \u0275\u0275element(5, "input", 12);
    \u0275\u0275template(6, LoginComponent_ng_template_8_mat_card_content_0_mat_error_6_Template, 2, 0, "mat-error", 13);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(7, "mat-form-field", 11)(8, "mat-label");
    \u0275\u0275text(9, "Client Secret:");
    \u0275\u0275elementEnd();
    \u0275\u0275element(10, "input", 14);
    \u0275\u0275elementStart(11, "button", 15);
    \u0275\u0275listener("click", function LoginComponent_ng_template_8_mat_card_content_0_Template_button_click_11_listener() {
      \u0275\u0275restoreView(_r3);
      const ctx_r1 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r1.togglePasswordVisibility());
    });
    \u0275\u0275elementStart(12, "mat-icon");
    \u0275\u0275text(13);
    \u0275\u0275elementEnd()();
    \u0275\u0275template(14, LoginComponent_ng_template_8_mat_card_content_0_mat_error_14_Template, 2, 0, "mat-error", 16);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(15, "button", 17);
    \u0275\u0275text(16, "Login");
    \u0275\u0275elementEnd();
    \u0275\u0275template(17, LoginComponent_ng_template_8_mat_card_content_0_button_17_Template, 2, 0, "button", 18);
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    let tmp_4_0;
    let tmp_7_0;
    const ctx_r1 = \u0275\u0275nextContext(2);
    \u0275\u0275advance();
    \u0275\u0275property("formGroup", ctx_r1.form);
    \u0275\u0275advance(5);
    \u0275\u0275property("ngIf", (tmp_4_0 = ctx_r1.form.get("clientId")) == null ? null : tmp_4_0.hasError("invalidGuid"));
    \u0275\u0275advance(4);
    \u0275\u0275property("type", ctx_r1.hidePassword ? "password" : "text");
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate(ctx_r1.hidePassword ? "visibility_off" : "visibility");
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", (tmp_7_0 = ctx_r1.form.get("clientSecret")) == null ? null : tmp_7_0.hasError("invalidGuid"));
    \u0275\u0275advance();
    \u0275\u0275property("disabled", ctx_r1.form.invalid);
    \u0275\u0275advance(2);
    \u0275\u0275property("ngIf", ctx_r1.providerInfo == null ? null : ctx_r1.providerInfo.oAuth2 == null ? null : ctx_r1.providerInfo.oAuth2.isActive);
  }
}
function LoginComponent_ng_template_8_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275template(0, LoginComponent_ng_template_8_mat_card_content_0_Template, 18, 7, "mat-card-content", 9);
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275property("ngIf", ctx_r1.selectedLogin);
  }
}
var _LoginComponent = class _LoginComponent {
  constructor(router, formBuilder, authService, snackBar, windowService, userPreferencesService) {
    this.router = router;
    this.formBuilder = formBuilder;
    this.authService = authService;
    this.snackBar = snackBar;
    this.windowService = windowService;
    this.userPreferencesService = userPreferencesService;
    this.hidePassword = true;
    this.selectedLogin = null;
    this.subscriptions = new Subscription();
  }
  ngOnInit() {
    if (this.authService.isAuthenticated || !this.authService.isAuthorizationRequired) {
      this.router.navigate([""]);
    }
    this.route = this.windowService.controllerOptions.route;
    this.providerInfo = this.windowService.providerInfo;
    this.serviceType = this.windowService.serviceType;
    this.packVersion = this.windowService.packVersion;
    if (!this.providerInfo.oAuth2.isActive) {
      this.selectedLogin = "basic";
    }
    this.form = this.formBuilder.group({
      clientId: ["", [Validators.required, CustomValidators.mustGuid]],
      clientSecret: ["", [Validators.required, CustomValidators.mustGuid]]
    });
  }
  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
  selectLogin(type) {
    this.selectedLogin = type;
  }
  onSubmit() {
    if (this.form.valid) {
      this.login();
    }
  }
  get clientId() {
    return this.form.get("clientId")?.value;
  }
  get clientSecret() {
    return this.form.get("clientSecret")?.value;
  }
  login() {
    const clientId = this.clientId;
    const clientSecret = this.clientSecret;
    if (!clientId || !clientSecret) {
      return;
    }
    const subscription = this.authService.basicAuthorize(clientId, clientSecret).subscribe((isAuthenticated) => {
      if (isAuthenticated) {
        this.router.navigate([""]);
        return;
      }
      const errorMessage = isAuthenticated === false ? `Error: Credentials are not valid!` : "Error: Exception occurred while the processing";
      this.snackBar.open(errorMessage, "Close", {
        horizontalPosition: "center",
        verticalPosition: "top",
        duration: 2250
      });
    });
    this.subscriptions.add(subscription);
  }
  handleOauth() {
    let url = this.route + "/v1/auth/login";
    if (this.serviceType === "Consumer") {
      url += `?uuid=${this.userPreferencesService.uuid}`;
    }
    this.userPreferencesService.setAuth("oauth2");
    window.location.href = url;
  }
  reset() {
    this.selectedLogin = null;
    this.form.get("clientId")?.setValue("");
    this.form.get("clientSecret")?.setValue("");
  }
  togglePasswordVisibility() {
    this.hidePassword = !this.hidePassword;
  }
};
_LoginComponent.\u0275fac = function LoginComponent_Factory(t) {
  return new (t || _LoginComponent)(\u0275\u0275directiveInject(Router), \u0275\u0275directiveInject(FormBuilder), \u0275\u0275directiveInject(AuthService), \u0275\u0275directiveInject(MatSnackBar), \u0275\u0275directiveInject(WindowService), \u0275\u0275directiveInject(UserPreferencesService));
};
_LoginComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _LoginComponent, selectors: [["app-login"]], decls: 10, vars: 4, consts: [["basicLogin", ""], [1, "login-container"], [1, "login-card"], [1, "login-title"], ["class", "mt-2", 4, "ngIf", "ngIfElse"], [1, "position-absolute", "b-0", "p-2", "text-muted"], [1, "mt-2"], ["mat-raised-button", "", "color", "primary", 1, "w-100", 3, "click"], ["mat-raised-button", "", "color", "accent", 1, "w-100", "mt-2", 3, "click"], ["class", "mt-2", 4, "ngIf"], [3, "ngSubmit", "formGroup"], ["appearance", "outline", 1, "mb-1"], ["matInput", "", "type", "text", "formControlName", "clientId"], ["class", "text-align-start", 4, "ngIf"], ["matInput", "", "formControlName", "clientSecret", 3, "type"], ["mat-icon-button", "", "matSuffix", "", 3, "click"], [4, "ngIf"], ["type", "submit", "mat-raised-button", "", "color", "primary", 1, "w-100", 3, "disabled"], ["mat-stroked-button", "", "color", "warn", "class", "w-100 mt-2", 3, "click", 4, "ngIf"], [1, "text-align-start"], ["mat-stroked-button", "", "color", "warn", 1, "w-100", "mt-2", 3, "click"]], template: function LoginComponent_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "div", 1)(1, "mat-card", 2)(2, "mat-card-title", 3);
    \u0275\u0275text(3);
    \u0275\u0275elementEnd();
    \u0275\u0275element(4, "mat-divider");
    \u0275\u0275template(5, LoginComponent_div_5_Template, 9, 0, "div", 4);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(6, "div", 5);
    \u0275\u0275text(7);
    \u0275\u0275elementEnd()();
    \u0275\u0275template(8, LoginComponent_ng_template_8_Template, 1, 1, "ng-template", null, 0, \u0275\u0275templateRefExtractor);
  }
  if (rf & 2) {
    const basicLogin_r5 = \u0275\u0275reference(9);
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate(ctx.selectedLogin ? "Basic Authentication" : "Please choose your preferred login");
    \u0275\u0275advance(2);
    \u0275\u0275property("ngIf", !ctx.selectedLogin)("ngIfElse", basicLogin_r5);
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate1("v", ctx.packVersion, "");
  }
}, dependencies: [NgIf, \u0275NgNoValidate, DefaultValueAccessor, NgControlStatus, NgControlStatusGroup, FormGroupDirective, FormControlName, MatButton, MatIconButton, MatIcon, MatFormField, MatLabel, MatError, MatSuffix, MatCard, MatCardContent, MatCardTitle, MatDivider, MatInput], styles: ["\n\n.login-container[_ngcontent-%COMP%] {\n  display: flex;\n  justify-content: center;\n  align-items: center;\n  height: 100vh;\n}\n.login-card[_ngcontent-%COMP%] {\n  padding: 30px;\n  max-width: 450px;\n  width: 100%;\n  text-align: center;\n  border-radius: 10px;\n  min-height: 200px;\n}\n.login-title[_ngcontent-%COMP%] {\n  font-size: 1.3rem;\n  font-weight: 500;\n  padding-bottom: 15px;\n}\nbutton[_ngcontent-%COMP%] {\n  border-radius: 5px;\n}\n/*# sourceMappingURL=login.component.css.map */"] });
var LoginComponent = _LoginComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(LoginComponent, { className: "LoginComponent", filePath: "src\\app\\features\\login\\login.component.ts", lineNumber: 17 });
})();

// src/app/features/login/login-routing.module.ts
var routes = [
  { path: "", component: LoginComponent },
  { path: "**", redirectTo: "" }
];
var _LoginRoutingModule = class _LoginRoutingModule {
};
_LoginRoutingModule.\u0275fac = function LoginRoutingModule_Factory(t) {
  return new (t || _LoginRoutingModule)();
};
_LoginRoutingModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _LoginRoutingModule });
_LoginRoutingModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [RouterModule.forChild(routes), RouterModule] });
var LoginRoutingModule = _LoginRoutingModule;

// src/app/features/login/login.module.ts
var _LoginModule = class _LoginModule {
};
_LoginModule.\u0275fac = function LoginModule_Factory(t) {
  return new (t || _LoginModule)();
};
_LoginModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _LoginModule });
_LoginModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [
  CommonModule,
  LoginRoutingModule,
  ReactiveFormsModule,
  MatButtonModule,
  MatIconModule,
  MatTooltipModule,
  MatFormFieldModule,
  MatCardModule,
  MatDividerModule,
  MatInputModule
] });
var LoginModule = _LoginModule;
export {
  LoginModule
};
//# sourceMappingURL=chunk-7CZV42H7.js.map
