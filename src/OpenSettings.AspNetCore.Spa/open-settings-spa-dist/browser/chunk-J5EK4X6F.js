import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle
} from "./chunk-HQT7NEGY.js";
import {
  MatTooltip
} from "./chunk-AXECPBMH.js";
import {
  ActivatedRoute,
  BehaviorSubject,
  MatButton,
  NgIf,
  RouterOutlet,
  ɵsetClassDebugInfo,
  ɵɵadvance,
  ɵɵdefineComponent,
  ɵɵdefineInjectable,
  ɵɵdirectiveInject,
  ɵɵelement,
  ɵɵelementEnd,
  ɵɵelementStart,
  ɵɵgetCurrentView,
  ɵɵlistener,
  ɵɵnextContext,
  ɵɵproperty,
  ɵɵresetView,
  ɵɵrestoreView,
  ɵɵsanitizeHtml,
  ɵɵtemplate,
  ɵɵtext,
  ɵɵtextInterpolate
} from "./chunk-SUR7UARE.js";

// src/app/shared/components/conflict-resolver-dialog/conflict-resolver-dialog.component.ts
function ConflictResolverDialogComponent_button_8_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 8);
    \u0275\u0275listener("click", function ConflictResolverDialogComponent_button_8_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r1);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.onSubmit("Discard"));
    });
    \u0275\u0275text(1, "Discard");
    \u0275\u0275elementEnd();
  }
}
function ConflictResolverDialogComponent_button_9_Template(rf, ctx) {
  if (rf & 1) {
    const _r3 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 9);
    \u0275\u0275listener("click", function ConflictResolverDialogComponent_button_9_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r3);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.onSubmit("Override"));
    });
    \u0275\u0275text(1, "Override");
    \u0275\u0275elementEnd();
  }
}
function ConflictResolverDialogComponent_button_10_Template(rf, ctx) {
  if (rf & 1) {
    const _r4 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 10);
    \u0275\u0275listener("click", function ConflictResolverDialogComponent_button_10_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r4);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.onSubmit("Recreate"));
    });
    \u0275\u0275text(1, "Recreate");
    \u0275\u0275elementEnd();
  }
}
function ConflictResolverDialogComponent_button_11_Template(rf, ctx) {
  if (rf & 1) {
    const _r5 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 11);
    \u0275\u0275listener("click", function ConflictResolverDialogComponent_button_11_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r5);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.onSubmit("Fetch Latest"));
    });
    \u0275\u0275text(1, "Fetch Latest");
    \u0275\u0275elementEnd();
  }
}
var _ConflictResolverDialogComponent = class _ConflictResolverDialogComponent {
  constructor(dialogRef, availableReturnTypes) {
    this.dialogRef = dialogRef;
    this.availableReturnTypes = availableReturnTypes;
    this.title = "Conflict occurred";
    this.actionText = "Please select your action";
    this.overrideBtnEnabled = availableReturnTypes.includes("Override");
    this.recreateBtnEnabled = availableReturnTypes.includes("Recreate");
    this.discardBtnEnabled = availableReturnTypes.includes("Discard");
    this.fetchLatestBtnEnabled = availableReturnTypes.includes("Fetch Latest");
  }
  onSubmit(returnType) {
    this.dialogRef.close(returnType);
  }
};
_ConflictResolverDialogComponent.\u0275fac = function ConflictResolverDialogComponent_Factory(t) {
  return new (t || _ConflictResolverDialogComponent)(\u0275\u0275directiveInject(MatDialogRef), \u0275\u0275directiveInject(MAT_DIALOG_DATA));
};
_ConflictResolverDialogComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _ConflictResolverDialogComponent, selectors: [["ng-component"]], decls: 12, vars: 7, consts: [["mat-dialog-title", ""], ["mat-dialog-content", ""], [3, "innerHTML"], ["mat-dialog-actions", ""], ["mat-button", "", "matTooltip", "Do nothing.", 3, "click", 4, "ngIf"], ["mat-raised-button", "", "color", "warn", "type", "submit", "matTooltip", "Replace existing data with your changes.", 3, "click", 4, "ngIf"], ["mat-raised-button", "", "color", "primary", "type", "submit", "matToolTip", "", 3, "click", 4, "ngIf"], ["mat-raised-button", "", "color", "warn", "type", "submit", "matTooltip", "You'll lose your changes if any.", 3, "click", 4, "ngIf"], ["mat-button", "", "matTooltip", "Do nothing.", 3, "click"], ["mat-raised-button", "", "color", "warn", "type", "submit", "matTooltip", "Replace existing data with your changes.", 3, "click"], ["mat-raised-button", "", "color", "primary", "type", "submit", "matToolTip", "", 3, "click"], ["mat-raised-button", "", "color", "warn", "type", "submit", "matTooltip", "You'll lose your changes if any.", 3, "click"]], template: function ConflictResolverDialogComponent_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "h1", 0);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(2, "div", 1);
    \u0275\u0275element(3, "p", 2);
    \u0275\u0275elementStart(4, "div")(5, "p");
    \u0275\u0275text(6);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(7, "div", 3);
    \u0275\u0275template(8, ConflictResolverDialogComponent_button_8_Template, 2, 0, "button", 4)(9, ConflictResolverDialogComponent_button_9_Template, 2, 0, "button", 5)(10, ConflictResolverDialogComponent_button_10_Template, 2, 0, "button", 6)(11, ConflictResolverDialogComponent_button_11_Template, 2, 0, "button", 7);
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(ctx.title);
    \u0275\u0275advance(2);
    \u0275\u0275property("innerHTML", ctx.recreateBtnEnabled ? "The data is no longer exists." : "The data has been updated since you last opened it.", \u0275\u0275sanitizeHtml);
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate(ctx.actionText);
    \u0275\u0275advance(2);
    \u0275\u0275property("ngIf", ctx.discardBtnEnabled);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.overrideBtnEnabled);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.recreateBtnEnabled);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.fetchLatestBtnEnabled);
  }
}, dependencies: [NgIf, MatDialogTitle, MatDialogActions, MatDialogContent, MatButton, MatTooltip], encapsulation: 2 });
var ConflictResolverDialogComponent = _ConflictResolverDialogComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(ConflictResolverDialogComponent, { className: "ConflictResolverDialogComponent", filePath: "src\\app\\shared\\components\\conflict-resolver-dialog\\conflict-resolver-dialog.component.ts", lineNumber: 10 });
})();

// src/app/features/sponsor/models/set-order-position.enum.ts
var SetSortOrderPosition;
(function(SetSortOrderPosition2) {
  SetSortOrderPosition2[SetSortOrderPosition2["Manual"] = -1] = "Manual";
  SetSortOrderPosition2[SetSortOrderPosition2["Bottom"] = 1] = "Bottom";
  SetSortOrderPosition2[SetSortOrderPosition2["Top"] = 2] = "Top";
})(SetSortOrderPosition || (SetSortOrderPosition = {}));

// src/app/shared/components/dummy/dummy-component.service.ts
var _DummyComponentService = class _DummyComponentService {
  constructor() {
    this.eventSubject = new BehaviorSubject(void 0);
    this.event$ = this.eventSubject.asObservable();
  }
  emitEvent(model) {
    this.eventSubject.next(model);
  }
};
_DummyComponentService.\u0275fac = function DummyComponentService_Factory(t) {
  return new (t || _DummyComponentService)();
};
_DummyComponentService.\u0275prov = /* @__PURE__ */ \u0275\u0275defineInjectable({ token: _DummyComponentService, factory: _DummyComponentService.\u0275fac, providedIn: "root" });
var DummyComponentService = _DummyComponentService;

// src/app/shared/components/dummy/dummy.component.ts
var _DummyComponent = class _DummyComponent {
  constructor(route, dummyComponentService) {
    this.route = route;
    this.dummyComponentService = dummyComponentService;
  }
  ngOnInit() {
    const path = this.route.snapshot.data["path"];
    const data = this.route.snapshot.data["data"];
    if (path) {
      this.dummyComponentService.emitEvent({
        path,
        data,
        activatedSnapshot: this.route.snapshot,
        activatedRoute: this.route
      });
    }
  }
  ngOnDestroy() {
    this.dummyComponentService.emitEvent(void 0);
  }
};
_DummyComponent.\u0275fac = function DummyComponent_Factory(t) {
  return new (t || _DummyComponent)(\u0275\u0275directiveInject(ActivatedRoute), \u0275\u0275directiveInject(DummyComponentService));
};
_DummyComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _DummyComponent, selectors: [["app-dummy-parent"]], decls: 1, vars: 0, template: function DummyComponent_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "router-outlet");
  }
}, dependencies: [RouterOutlet], encapsulation: 2 });
var DummyComponent = _DummyComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(DummyComponent, { className: "DummyComponent", filePath: "src\\app\\shared\\components\\dummy\\dummy.component.ts", lineNumber: 9 });
})();

export {
  ConflictResolverDialogComponent,
  SetSortOrderPosition,
  DummyComponentService,
  DummyComponent
};
//# sourceMappingURL=chunk-J5EK4X6F.js.map
