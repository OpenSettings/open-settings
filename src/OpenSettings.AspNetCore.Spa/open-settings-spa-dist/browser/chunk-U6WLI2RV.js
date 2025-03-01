import {
  GroupsService
} from "./chunk-ZOLOB6KZ.js";
import {
  CdkDrag,
  CdkDropList,
  DragDropModule,
  MatPaginator,
  MatPaginatorModule,
  MatSort,
  MatSortHeader,
  MatSortModule
} from "./chunk-AIE3AJ2I.js";
import {
  ConflictResolverDialogComponent,
  DummyComponent,
  DummyComponentService,
  SetSortOrderPosition
} from "./chunk-J5EK4X6F.js";
import {
  MatCell,
  MatCellDef,
  MatColumnDef,
  MatHeaderCell,
  MatHeaderCellDef,
  MatHeaderRow,
  MatHeaderRowDef,
  MatRow,
  MatRowDef,
  MatTable,
  MatTableDataSource,
  MatTableModule
} from "./chunk-BTPWLNSG.js";
import {
  SortDirection
} from "./chunk-EB7MRBEE.js";
import {
  UtilityService
} from "./chunk-4H4XXYOP.js";
import {
  MatSnackBar
} from "./chunk-JQUQ3G7S.js";
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
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogClose,
  MatDialogContent,
  MatDialogModule,
  MatDialogRef,
  MatDialogTitle
} from "./chunk-HQT7NEGY.js";
import {
  DefaultValueAccessor,
  FormBuilder,
  FormControlName,
  FormGroupDirective,
  MatCard,
  MatCardContent,
  MatCardModule,
  MatError,
  MatFormField,
  MatFormFieldModule,
  MatHint,
  MatIcon,
  MatIconModule,
  MatInput,
  MatInputModule,
  MatLabel,
  MatSuffix,
  MatTooltip,
  MatTooltipModule,
  NgControlStatus,
  NgControlStatusGroup,
  NumberValueAccessor,
  ReactiveFormsModule,
  Validators,
  ɵNgNoValidate
} from "./chunk-AXECPBMH.js";
import {
  ActivatedRoute,
  CommonModule,
  DatePipe,
  MatButton,
  MatButtonModule,
  MatFabButton,
  MatIconButton,
  MatOption,
  NgClass,
  NgIf,
  Router,
  RouterLink,
  RouterModule,
  RouterOutlet,
  Subject,
  Subscription,
  UserPreferencesService,
  WindowService,
  catchError,
  debounceTime,
  of,
  switchMap,
  ɵsetClassDebugInfo,
  ɵɵadvance,
  ɵɵclassProp,
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
  ɵɵloadQuery,
  ɵɵnextContext,
  ɵɵpipe,
  ɵɵpipeBind2,
  ɵɵproperty,
  ɵɵpureFunction0,
  ɵɵpureFunction1,
  ɵɵqueryRefresh,
  ɵɵreference,
  ɵɵresetView,
  ɵɵrestoreView,
  ɵɵtemplate,
  ɵɵtext,
  ɵɵtextInterpolate,
  ɵɵtextInterpolate1,
  ɵɵviewQuery
} from "./chunk-SUR7UARE.js";

// src/app/features/group/app-group-routes.ts
var GROUP_ROUTES = {
  base: "",
  create: "create",
  update: ":slug/update"
};

// src/app/features/group/components/app-group-upsert/app-group-upsert.component.ts
function AppGroupUpsertComponent_button_8_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 13);
    \u0275\u0275listener("click", function AppGroupUpsertComponent_button_8_Template_button_click_0_listener() {
      let tmp_2_0;
      \u0275\u0275restoreView(_r1);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView((tmp_2_0 = ctx_r1.myForm.get("name")) == null ? null : tmp_2_0.setValue(""));
    });
    \u0275\u0275element(1, "mat-icon", 14);
    \u0275\u0275elementEnd();
  }
}
var _AppGroupUpsertComponent = class _AppGroupUpsertComponent {
  constructor(snackBar, formBuilder, groupsService, dialog, dialogRef, model) {
    this.snackBar = snackBar;
    this.formBuilder = formBuilder;
    this.groupsService = groupsService;
    this.dialog = dialog;
    this.dialogRef = dialogRef;
    this.model = model;
    this.isManualSortOrder = false;
    this.setSortOrderPositions = SetSortOrderPosition;
    this.defaultPosition = SetSortOrderPosition.Bottom;
    this.subscriptions = new Subscription();
  }
  ngOnInit() {
    const id = this.model.id ?? "0";
    if (id == "0") {
      this.title = "Create a new group";
    } else {
      this.title = "Update - Group";
      this.isManualSortOrder = true;
      this.defaultPosition = SetSortOrderPosition.Manual;
    }
    this.myForm = this.formBuilder.group({
      id: [id],
      name: [this.model.name, Validators.required],
      position: [this.defaultPosition],
      sortOrder: [this.model.sortOrder],
      rowVersion: [this.model.rowVersion]
    });
  }
  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
  onSubmit() {
    if (!this.myForm.valid) {
      return;
    }
    const formValue = this.myForm.value;
    this.update(formValue);
  }
  update(formValue) {
    if (formValue.id === "0") {
      const trimmedName = formValue.name.trim();
      const subscription2 = this.groupsService.createGroup({
        body: {
          name: trimmedName,
          sortOrder: formValue.sortOrder,
          setSortOrderPosition: formValue.position === -1 ? void 0 : formValue.position
        }
      }).subscribe({
        next: (response) => {
          const responseData = response.data;
          if (!responseData) {
            return;
          }
          const returnModel = {
            id: responseData.id,
            name: responseData.name,
            sortOrder: responseData.sortOrder
          };
          this.snackBar.open(`Data has been added successfully!`, "Close", {
            horizontalPosition: "right",
            verticalPosition: "top",
            duration: 5e3
          });
          this.dialogRef?.close(returnModel);
        }
      });
      this.subscriptions.add(subscription2);
      return;
    }
    const updateGroup = (formValue2, rowVersion) => {
      return this.groupsService.updateGroup({
        groupId: formValue2.id,
        body: {
          name: formValue2.name,
          sortOrder: formValue2.sortOrder,
          setSortOrderPosition: formValue2.position === -1 ? void 0 : formValue2.position,
          rowVersion
        }
      });
    };
    const createGroup = (formValue2) => {
      return this.groupsService.createGroup({
        body: {
          name: formValue2.name,
          sortOrder: formValue2.sortOrder,
          setSortOrderPosition: formValue2.position === -1 ? void 0 : formValue2.position
        }
      });
    };
    const handleUpdate = (formValue2, currentRowVersion) => {
      return updateGroup(formValue2, currentRowVersion).pipe(switchMap((response) => {
        const responseData = response.data;
        if (!responseData && response.extras) {
          const conflictedData = response.extras["Conflicts"][formValue2.id];
          const availableReturnTypes = ["Discard"];
          availableReturnTypes.push(conflictedData ? "Recreate" : "Override");
          return this.dialog.open(ConflictResolverDialogComponent, {
            width: "400px",
            data: availableReturnTypes,
            autoFocus: false
          }).afterClosed().pipe(switchMap((type) => {
            if (type === "Override") {
              const rowVersion = conflictedData.properties["RowVersion"].current;
              return handleUpdate(formValue2, rowVersion);
            } else if (type === "Recreate") {
              return createGroup(formValue2).pipe(switchMap(() => {
                return of(true);
              }));
            }
            return of(false);
          }));
        } else {
          this.snackBar.open(`Data has been updated successfully!`, "Close", {
            horizontalPosition: "right",
            verticalPosition: "top",
            duration: 5e3
          });
        }
        return of(true);
      }), catchError((err) => {
        this.snackBar.open(`An error occurred or action not completed.`, "Close", {
          horizontalPosition: "right",
          verticalPosition: "top",
          duration: 5e3
        });
        return err;
      }));
    };
    const subscription = handleUpdate(formValue, formValue.rowVersion).subscribe({
      next: (close) => {
        if (close) {
          this.dialogRef?.close();
        }
      }
    });
    this.subscriptions.add(subscription);
  }
  onPositionChange() {
    const position = this.myForm.get("position")?.value;
    if (position === -1) {
      this.isManualSortOrder = true;
    } else {
      this.isManualSortOrder = false;
    }
  }
};
_AppGroupUpsertComponent.\u0275fac = function AppGroupUpsertComponent_Factory(t) {
  return new (t || _AppGroupUpsertComponent)(\u0275\u0275directiveInject(MatSnackBar), \u0275\u0275directiveInject(FormBuilder), \u0275\u0275directiveInject(GroupsService), \u0275\u0275directiveInject(MatDialog), \u0275\u0275directiveInject(MatDialogRef), \u0275\u0275directiveInject(MAT_DIALOG_DATA));
};
_AppGroupUpsertComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _AppGroupUpsertComponent, selectors: [["app-group-upsert"]], decls: 34, vars: 9, consts: [[3, "formGroup"], ["mat-dialog-title", ""], [1, "pb-0"], ["appearance", "fill"], ["matInput", "", "formControlName", "name", 3, "maxLength"], ["mat-icon-button", "", "matSuffix", "", "type", "button", 3, "click", 4, "ngIf"], ["formControlName", "position", 3, "selectionChange"], [3, "value"], ["appearance", "fill", 3, "ngClass"], ["matInput", "", "formControlName", "sortOrder", "type", "number"], [1, "mt-1"], ["mat-button", "", "color", "accent", "mat-dialog-close", "", 1, "mr-1"], ["mat-raised-button", "", "color", "primary", 3, "click", "disabled"], ["mat-icon-button", "", "matSuffix", "", "type", "button", 3, "click"], ["fontIcon", "clear"]], template: function AppGroupUpsertComponent_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "form", 0)(1, "h2", 1);
    \u0275\u0275text(2);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "mat-dialog-content", 2)(4, "mat-form-field", 3)(5, "mat-label");
    \u0275\u0275text(6, "Name");
    \u0275\u0275elementEnd();
    \u0275\u0275element(7, "input", 4);
    \u0275\u0275template(8, AppGroupUpsertComponent_button_8_Template, 2, 0, "button", 5);
    \u0275\u0275elementStart(9, "mat-error");
    \u0275\u0275text(10, "Please provide a valid value");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(11, "mat-form-field", 3)(12, "mat-label");
    \u0275\u0275text(13, "Position");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(14, "mat-select", 6);
    \u0275\u0275listener("selectionChange", function AppGroupUpsertComponent_Template_mat_select_selectionChange_14_listener() {
      return ctx.onPositionChange();
    });
    \u0275\u0275elementStart(15, "mat-option", 7);
    \u0275\u0275text(16, "Manual");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(17, "mat-option", 7);
    \u0275\u0275text(18, "Top");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(19, "mat-option", 7);
    \u0275\u0275text(20, "Bottom");
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(21, "mat-form-field", 8)(22, "mat-label");
    \u0275\u0275text(23, "Sort Order");
    \u0275\u0275elementEnd();
    \u0275\u0275element(24, "input", 9);
    \u0275\u0275elementStart(25, "mat-error");
    \u0275\u0275text(26, "Please provide a valid value");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(27, "mat-hint");
    \u0275\u0275text(28, "Lower values will appear first in the list.");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(29, "div", 10)(30, "button", 11);
    \u0275\u0275text(31, "Cancel");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(32, "button", 12);
    \u0275\u0275listener("click", function AppGroupUpsertComponent_Template_button_click_32_listener() {
      return ctx.onSubmit();
    });
    \u0275\u0275text(33, "Save");
    \u0275\u0275elementEnd()()()();
  }
  if (rf & 2) {
    let tmp_3_0;
    \u0275\u0275property("formGroup", ctx.myForm);
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate(ctx.title);
    \u0275\u0275advance(5);
    \u0275\u0275property("maxLength", 50);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", (tmp_3_0 = ctx.myForm.get("name")) == null ? null : tmp_3_0.value);
    \u0275\u0275advance(7);
    \u0275\u0275property("value", -1);
    \u0275\u0275advance(2);
    \u0275\u0275property("value", ctx.setSortOrderPositions.Top);
    \u0275\u0275advance(2);
    \u0275\u0275property("value", ctx.setSortOrderPositions.Bottom);
    \u0275\u0275advance(2);
    \u0275\u0275property("ngClass", ctx.isManualSortOrder ? "" : "collapse d-none");
    \u0275\u0275advance(11);
    \u0275\u0275property("disabled", ctx.myForm.invalid);
  }
}, dependencies: [NgClass, NgIf, \u0275NgNoValidate, DefaultValueAccessor, NumberValueAccessor, NgControlStatus, NgControlStatusGroup, FormGroupDirective, FormControlName, MatFormField, MatLabel, MatHint, MatError, MatSuffix, MatButton, MatIconButton, MatIcon, MatDialogClose, MatDialogTitle, MatDialogContent, MatSelect, MatOption, MatInput], encapsulation: 2 });
var AppGroupUpsertComponent = _AppGroupUpsertComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(AppGroupUpsertComponent, { className: "AppGroupUpsertComponent", filePath: "src\\app\\features\\group\\components\\app-group-upsert\\app-group-upsert.component.ts", lineNumber: 16 });
})();

// src/app/features/group/components/app-group-list/app-group-list.component.ts
var _c0 = ["searchTermInput"];
var _c1 = () => [8, 16, 32, 64];
var _c2 = () => ["./create"];
var _c3 = (a0) => [a0, "update"];
function AppGroupListComponent_button_5_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "button", 30)(1, "mat-icon");
    \u0275\u0275text(2, "more_vert");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    \u0275\u0275nextContext();
    const listOptions_r2 = \u0275\u0275reference(7);
    \u0275\u0275property("matMenuTriggerFor", listOptions_r2);
  }
}
function AppGroupListComponent_button_26_Template(rf, ctx) {
  if (rf & 1) {
    const _r3 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 31);
    \u0275\u0275listener("click", function AppGroupListComponent_button_26_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r3);
      const ctx_r3 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r3.clearSearchTerm());
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "clear");
    \u0275\u0275elementEnd()();
  }
}
function AppGroupListComponent_mat_card_content_27_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-card-content", 32);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r3 = \u0275\u0275nextContext();
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(ctx_r3.message);
  }
}
function AppGroupListComponent_th_30_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "th", 33);
    \u0275\u0275text(1, "Id");
    \u0275\u0275elementEnd();
  }
}
function AppGroupListComponent_td_31_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "td", 34);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const data_r5 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(data_r5.id);
  }
}
function AppGroupListComponent_th_33_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "th", 33);
    \u0275\u0275text(1, "Name");
    \u0275\u0275elementEnd();
  }
}
function AppGroupListComponent_td_34_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "td", 34);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const data_r6 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(data_r6.name);
  }
}
function AppGroupListComponent_th_36_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "th", 33);
    \u0275\u0275text(1, "Sort Order");
    \u0275\u0275elementEnd();
  }
}
function AppGroupListComponent_td_37_button_2_Template(rf, ctx) {
  if (rf & 1) {
    const _r7 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 37);
    \u0275\u0275listener("click", function AppGroupListComponent_td_37_button_2_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r7);
      const data_r8 = \u0275\u0275nextContext().$implicit;
      const ctx_r3 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r3.moveUpOrder(data_r8));
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "arrow_upward");
    \u0275\u0275elementEnd()();
  }
}
function AppGroupListComponent_td_37_button_3_Template(rf, ctx) {
  if (rf & 1) {
    const _r9 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 38);
    \u0275\u0275listener("click", function AppGroupListComponent_td_37_button_3_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r9);
      const data_r8 = \u0275\u0275nextContext().$implicit;
      const ctx_r3 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r3.moveDownOrder(data_r8));
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "arrow_downward");
    \u0275\u0275elementEnd()();
  }
}
function AppGroupListComponent_td_37_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "td", 34);
    \u0275\u0275text(1);
    \u0275\u0275template(2, AppGroupListComponent_td_37_button_2_Template, 3, 0, "button", 35)(3, AppGroupListComponent_td_37_button_3_Template, 3, 0, "button", 36);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const data_r8 = ctx.$implicit;
    const ctx_r3 = \u0275\u0275nextContext();
    \u0275\u0275advance();
    \u0275\u0275textInterpolate1(" ", data_r8.sortOrder, " ");
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", data_r8.sortOrder !== ctx_r3.minSortOrder);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", data_r8.sortOrder !== ctx_r3.maxSortOrder);
  }
}
function AppGroupListComponent_th_39_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "th", 33);
    \u0275\u0275text(1, "Mappings Count");
    \u0275\u0275elementEnd();
  }
}
function AppGroupListComponent_td_40_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "td", 34);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const data_r10 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(data_r10.mappingsCount);
  }
}
function AppGroupListComponent_th_42_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "th", 33);
    \u0275\u0275text(1, "Created On");
    \u0275\u0275elementEnd();
  }
}
function AppGroupListComponent_td_43_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "td", 34);
    \u0275\u0275text(1);
    \u0275\u0275pipe(2, "date");
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const data_r11 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(\u0275\u0275pipeBind2(2, 1, data_r11.createdOn, "dd-MM-yyyy HH:mm"));
  }
}
function AppGroupListComponent_th_45_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "th", 33);
    \u0275\u0275text(1, "Created By");
    \u0275\u0275elementEnd();
  }
}
function AppGroupListComponent_td_46_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "td", 34);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const data_r12 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(data_r12.createdBy);
  }
}
function AppGroupListComponent_th_48_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "th", 33);
    \u0275\u0275text(1, "Updated On");
    \u0275\u0275elementEnd();
  }
}
function AppGroupListComponent_td_49_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "td", 34);
    \u0275\u0275text(1);
    \u0275\u0275pipe(2, "date");
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const data_r13 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(\u0275\u0275pipeBind2(2, 1, data_r13.updatedOn, "dd-MM-yyyy HH:mm"));
  }
}
function AppGroupListComponent_th_51_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "th", 33);
    \u0275\u0275text(1, "Updated By");
    \u0275\u0275elementEnd();
  }
}
function AppGroupListComponent_td_52_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "td", 34);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const data_r14 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(data_r14.updatedBy);
  }
}
function AppGroupListComponent_th_54_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "th", 39);
  }
}
function AppGroupListComponent_td_55_Template(rf, ctx) {
  if (rf & 1) {
    const _r15 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "td", 34)(1, "button", 30)(2, "mat-icon");
    \u0275\u0275text(3, "more_vert");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(4, "mat-menu", null, 2)(6, "button", 40)(7, "mat-icon");
    \u0275\u0275text(8, "edit");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(9, "span");
    \u0275\u0275text(10, "Update");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(11, "button", 7);
    \u0275\u0275listener("click", function AppGroupListComponent_td_55_Template_button_click_11_listener() {
      const data_r16 = \u0275\u0275restoreView(_r15).$implicit;
      const ctx_r3 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r3.delete(data_r16));
    });
    \u0275\u0275elementStart(12, "mat-icon");
    \u0275\u0275text(13, "delete");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(14, "span");
    \u0275\u0275text(15, "Delete");
    \u0275\u0275elementEnd()()()();
  }
  if (rf & 2) {
    const data_r16 = ctx.$implicit;
    const menu_r17 = \u0275\u0275reference(5);
    \u0275\u0275advance();
    \u0275\u0275property("matMenuTriggerFor", menu_r17);
    \u0275\u0275advance(5);
    \u0275\u0275property("routerLink", \u0275\u0275pureFunction1(2, _c3, data_r16.slug));
  }
}
function AppGroupListComponent_tr_56_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "tr", 41);
  }
}
function AppGroupListComponent_tr_57_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "tr", 42);
  }
}
function AppGroupListComponent_mat_progress_bar_62_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "mat-progress-bar", 43);
  }
}
var _AppGroupListComponent = class _AppGroupListComponent {
  constructor(groupsService, dialog, snackBar, windowService, dummyComponentService, utilityService, userPreferencesService, route, router) {
    this.groupsService = groupsService;
    this.dialog = dialog;
    this.snackBar = snackBar;
    this.windowService = windowService;
    this.dummyComponentService = dummyComponentService;
    this.utilityService = utilityService;
    this.userPreferencesService = userPreferencesService;
    this.route = route;
    this.router = router;
    this.displayedColumns = ["id", "name", "sortOrder", "mappingsCount", "createdOn", "createdBy", "updatedOn", "updatedBy", "edit"];
    this.dataSource = new MatTableDataSource();
    this.queryParams = {
      pageSize: 0,
      pageIndex: 0,
      searchTerm: "",
      sortBy: "",
      sortDirection: null
    };
    this.searchTermSubject = new Subject();
    this.isProvider = false;
    this.subscriptions = new Subscription();
    this.dragAndDropEnabled = false;
    this.isLoading = false;
    this.noResultsFound = true;
    this.message = "";
    this.minSortOrder = 0;
    this.maxSortOrder = 0;
  }
  ngOnInit() {
    this.isProvider = this.windowService.isProvider;
    this.dragAndDropEnabled = this.userPreferencesService.dragAndDropEnabled;
    this.handleRouting();
    this.setupSearchTermSubscription();
  }
  ngAfterViewInit() {
    setTimeout(() => {
      this.setupQueryParams();
    });
  }
  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
  setupQueryParams() {
    if (this.queryParamSubscription) {
      return;
    }
    this.queryParamSubscription = this.route.queryParams.subscribe((params) => {
      const pageIndex = +params["page"] - 1 || 0;
      const pageSize = +params["size"] || 5;
      const sortBy = params["sortBy"] || "";
      const sortDirection = (params["sortDirection"]?.toLowerCase() ?? "0") === "0" ? sortBy === "" ? null : SortDirection.Asc : SortDirection.Desc;
      const searchTerm = this.getSearchTermFromRoute(params);
      if (this.queryParams.pageIndex === pageIndex && this.queryParams.pageSize === pageSize && this.queryParams.sortBy === sortBy && this.queryParams.sortDirection === sortDirection && this.queryParams.searchTerm === searchTerm) {
        return;
      }
      this.queryParams.pageIndex = pageIndex;
      this.queryParams.pageSize = pageSize;
      this.queryParams.sortBy = sortBy;
      this.queryParams.sortDirection = sortDirection;
      this.queryParams.searchTerm = searchTerm;
      this.searchTermInput.nativeElement.value = searchTerm;
      this.loadData();
    });
    this.subscriptions.add(this.queryParamSubscription);
  }
  setupSearchTermSubscription() {
    if (this.searchTermSubscription) {
      return;
    }
    this.searchTermSubscription = this.searchTermSubject.pipe(debounceTime(300)).subscribe((searchTerm) => {
      this.queryParams.searchTerm = searchTerm;
      this.loadData();
    });
    this.subscriptions.add(this.searchTermSubscription);
  }
  getSearchTermFromRoute(params) {
    let hasDifferentCaseSearchTerm = false;
    const filterKeys = Object.keys(params).filter((key) => {
      const isMatches = key.toLocaleLowerCase() === "searchterm";
      if (!hasDifferentCaseSearchTerm) {
        hasDifferentCaseSearchTerm = isMatches && key !== "searchTerm";
      }
      return isMatches;
    });
    return filterKeys.length > 0 ? hasDifferentCaseSearchTerm ? this.updateQueryParamsForSearchTerm(filterKeys, params) : params["searchTerm"] ?? "" : "";
  }
  updateQueryParamsForSearchTerm(searchTermKeys, params) {
    let searchTerm = "";
    const updatedParams = {};
    searchTermKeys.forEach((key) => {
      searchTerm += params[key] + ",";
      updatedParams[key] = null;
    });
    searchTerm = searchTerm.substring(0, searchTerm.length - 1);
    updatedParams["searchTerm"] = searchTerm;
    this.router.navigate([], {
      queryParams: updatedParams,
      queryParamsHandling: "merge"
    });
    return searchTerm;
  }
  setupSortChangeIfNotAlready(sortBy, sortDirection) {
    if (this.sortChangeSubscription) {
      return;
    }
    this.sort.active = sortBy;
    this.sort.direction = sortDirection === null ? "" : sortDirection === SortDirection.Desc ? "desc" : "asc";
    this.sortChangeSubscription = this.sort.sortChange.subscribe(() => {
      const sortBy2 = this.sort.direction === "" ? "" : this.sort.active;
      const sortDirection2 = this.sort.direction === "desc" ? SortDirection.Desc : this.sort.direction === "" ? null : SortDirection.Asc;
      if (sortBy2 === this.queryParams.sortBy && sortDirection2 === this.queryParams.sortDirection) {
        return;
      }
      this.queryParams.sortBy = sortBy2;
      this.queryParams.sortDirection = sortDirection2;
      this.loadData();
    });
    this.subscriptions.add(this.sortChangeSubscription);
  }
  onPaginate(event) {
    if (this.queryParams.pageIndex === event.pageIndex && this.queryParams.pageSize === event.pageSize) {
      return;
    }
    this.queryParams.pageIndex = event.pageIndex;
    this.queryParams.pageSize = event.pageSize;
    this.loadData();
  }
  loadData() {
    this.startFetching();
    const subscription = this.groupsService.getPaginatedGroups({
      searchTerm: this.queryParams.searchTerm,
      pageIndex: this.queryParams.pageIndex + 1,
      pageSize: this.queryParams.pageSize,
      sortBy: this.queryParams.sortBy,
      sortDirection: this.queryParams.sortDirection
    }).subscribe({
      next: (response) => {
        const responseData = response.data;
        if (!responseData) {
          return;
        }
        this.minSortOrder = responseData.minSortOrder;
        this.maxSortOrder = responseData.maxSortOrder;
        this.dataSource.data = responseData.appGroups;
        this.paginator.pageIndex = responseData.pagingInfo.pageIndex - 1;
        this.paginator.pageSize = responseData.pagingInfo.pageSize;
        this.paginator.length = responseData.pagingInfo.itemCount;
        this.queryParams.pageIndex = this.paginator.pageIndex;
        this.queryParams.pageSize = this.paginator.pageSize;
        this.stopFetching();
      },
      error: () => {
        this.stopFetching(true);
      },
      complete: () => {
        this.setupSortChangeIfNotAlready(this.queryParams.sortBy, this.queryParams.sortDirection);
        this.updateUrl();
      }
    });
    this.subscriptions.add(subscription);
  }
  startFetching() {
    this.isLoading = true;
  }
  stopFetching(hasError) {
    this.isLoading = false;
    if (hasError) {
      return;
    }
    if (this.dataSource.data.length > 0) {
      this.noResultsFound = false;
      this.message = "";
      return;
    }
    if (this.queryParams.searchTerm === "") {
      this.noResultsFound = true;
      this.message = "No results found.";
    } else {
      this.noResultsFound = false;
      this.message = "0 matches";
    }
  }
  applyFilter(event) {
    const searchTerm = event.target.value;
    if (searchTerm === this.queryParams.searchTerm) {
      return;
    }
    this.queryParams.pageIndex = 0;
    this.searchTermSubject.next(searchTerm);
  }
  clearSearchTerm() {
    if (this.queryParams.searchTerm === "") {
      return;
    }
    this.searchTermInput.nativeElement.value = "";
    this.queryParams.pageIndex = 0;
    this.queryParams.searchTerm = "";
    this.loadData();
  }
  updateUrl() {
    this.router.navigate([], {
      queryParams: {
        page: this.queryParams.pageIndex + 1,
        size: this.queryParams.pageSize,
        sortBy: this.queryParams.sortBy === "" ? null : this.queryParams.sortBy,
        sortDirection: this.queryParams.sortDirection,
        searchTerm: this.queryParams.searchTerm === "" ? null : this.queryParams.searchTerm
      },
      queryParamsHandling: "merge"
    });
  }
  handleRouting() {
    const dummyComponentSubscription = this.dummyComponentService.event$.subscribe((event) => {
      setTimeout(() => {
        if (event === void 0) {
          return;
        }
        switch (event.path) {
          case GROUP_ROUTES.create:
            this.add();
            break;
          case GROUP_ROUTES.update:
            const paramSubscription = event.activatedRoute.paramMap.subscribe((params) => {
              const slug = params.get("slug");
              if (!slug) {
                return;
              }
              const data = this.dataSource.data.find((d) => d.slug === slug);
              if (data) {
                this.update(data);
                return;
              }
              const internalSubscription = this.groupsService.getGroupBySlug({
                groupIdOrSlug: slug
              }).subscribe({
                next: (response) => {
                  const responseData = response.data;
                  if (!responseData) {
                    return;
                  }
                  const editModel = {
                    id: slug,
                    name: responseData.name,
                    sortOrder: responseData.sortOrder,
                    rowVersion: responseData.rowVersion
                  };
                  this.update(editModel);
                },
                error: (err) => {
                  this.router.navigate(["./"], { relativeTo: this.route, queryParamsHandling: "merge" });
                }
              });
              this.subscriptions.add(internalSubscription);
            });
            this.subscriptions.add(paramSubscription);
            break;
        }
      }, 0);
    });
    this.subscriptions.add(dummyComponentSubscription);
  }
  delete(model) {
    const title = "Confirm delete";
    let message = `Are you sure you want to delete the "${model.name}" group?`;
    let requireConfirmation = false;
    if (model.mappingsCount > 0) {
      message += " The group has " + model.mappingsCount + ' mapping(s). When deleted, the mapped apps in this group will be moved to the "Ungrouped apps" group.';
      requireConfirmation = true;
    }
    message += " This action cannot be undone.";
    const confirmationDialogComponentModel = {
      title,
      message,
      requireConfirmation
    };
    const subscription = this.dialog.open(ConfirmationDialogComponent, {
      width: "500px",
      data: confirmationDialogComponentModel
    }).afterClosed().subscribe((result) => {
      if (result) {
        const internalSubscription = this.groupsService.deleteGroup({ id: model.id, rowVersion: model.rowVersion }).subscribe((response) => {
          if (response.status === 409 && response.errors) {
            this.utilityService.error(response.errors, 3500);
          } else {
            this.snackBar.open(`Deleted successfully!`, "Close", {
              horizontalPosition: "right",
              verticalPosition: "top",
              duration: 5e3
            });
          }
          this.loadData();
        });
        this.subscriptions.add(internalSubscription);
      }
    });
    this.subscriptions.add(subscription);
  }
  moveUpOrder(model) {
    this.moveOrder(model, false);
  }
  moveDownOrder(model) {
    this.moveOrder(model, true);
  }
  moveOrder(model, ascent) {
    const subscription = this.groupsService.updateGroupSortOrder({
      id: model.id,
      ascent,
      rowVersion: model.rowVersion
    }).subscribe((response) => {
      if (response.status === 409 && response.errors) {
        this.utilityService.error(response.errors, 3500);
      }
      this.loadData();
    });
    this.subscriptions.add(subscription);
  }
  reorder() {
    const subscription = this.groupsService.reorder().subscribe(() => {
      this.snackBar.open(`Reordered successfully!`, "Close", {
        horizontalPosition: "right",
        verticalPosition: "top",
        duration: 5e3
      });
      this.loadData();
    });
    this.subscriptions.add(subscription);
  }
  add() {
    const groupEditComponentModel = {
      id: "0",
      name: "",
      sortOrder: 0,
      rowVersion: ""
    };
    const subscription = this.dialog.open(AppGroupUpsertComponent, {
      data: groupEditComponentModel,
      width: "500px",
      height: "370px",
      minWidth: "inherit",
      maxWidth: "inherit",
      autoFocus: true
    }).afterClosed().subscribe(() => {
      this.loadData();
      this.router.navigate(["./"], { relativeTo: this.route, queryParamsHandling: "merge" });
    });
    this.subscriptions.add(subscription);
  }
  update(model) {
    const subscription = this.dialog.open(AppGroupUpsertComponent, {
      data: model,
      width: "500px",
      height: "370px",
      minWidth: "inherit",
      maxWidth: "inherit",
      autoFocus: false
    }).afterClosed().subscribe(() => {
      this.loadData();
      this.router.navigate(["./"], { relativeTo: this.route, queryParamsHandling: "merge" });
    });
    this.subscriptions.add(subscription);
  }
  deleteUnmappedGroups() {
    const title = "Confirm delete";
    const message = `Are you sure you want to delete the unmapped groups? This action cannot be undone.`;
    const subscription = this.dialog.open(ConfirmationDialogComponent, {
      width: "500px",
      data: { title, message }
    }).afterClosed().subscribe((result) => {
      if (result) {
        const internalSubscription = this.groupsService.deleteUnmappedGroups().subscribe(() => {
          this.snackBar.open(`Deleted successfully!`, "Close", {
            horizontalPosition: "right",
            verticalPosition: "top",
            duration: 5e3
          });
          this.loadData();
        });
        this.subscriptions.add(internalSubscription);
      }
    });
    this.subscriptions.add(subscription);
  }
  onRowDrop(event) {
    const previousIndex = event.previousIndex;
    const currentIndex = event.currentIndex;
    if (previousIndex === currentIndex) {
      return;
    }
    const ascent = currentIndex > previousIndex;
    const source = this.dataSource.data[previousIndex];
    if (Math.abs(previousIndex - currentIndex) === 1) {
      this.moveOrder(source, ascent);
      return;
    }
    const target = this.dataSource.data[currentIndex];
    const subscription = this.groupsService.dragGroup({
      sourceId: source.id,
      targetId: target.id,
      ascent,
      sourceRowVersion: source.rowVersion
    }).subscribe((response) => {
      if (response.status === 409 && response.errors) {
        this.utilityService.error(response.errors, 3500);
      }
      this.loadData();
    });
    this.subscriptions.add(subscription);
  }
  toggleDragAndDrop() {
    this.dragAndDropEnabled = !this.dragAndDropEnabled;
    this.userPreferencesService.setDragAndDropEnabled(this.dragAndDropEnabled);
  }
};
_AppGroupListComponent.\u0275fac = function AppGroupListComponent_Factory(t) {
  return new (t || _AppGroupListComponent)(\u0275\u0275directiveInject(GroupsService), \u0275\u0275directiveInject(MatDialog), \u0275\u0275directiveInject(MatSnackBar), \u0275\u0275directiveInject(WindowService), \u0275\u0275directiveInject(DummyComponentService), \u0275\u0275directiveInject(UtilityService), \u0275\u0275directiveInject(UserPreferencesService), \u0275\u0275directiveInject(ActivatedRoute), \u0275\u0275directiveInject(Router));
};
_AppGroupListComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _AppGroupListComponent, selectors: [["ng-component"]], viewQuery: function AppGroupListComponent_Query(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275viewQuery(MatPaginator, 5);
    \u0275\u0275viewQuery(MatSort, 5);
    \u0275\u0275viewQuery(_c0, 5);
  }
  if (rf & 2) {
    let _t;
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.paginator = _t.first);
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.sort = _t.first);
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.searchTermInput = _t.first);
  }
}, decls: 64, vars: 19, consts: [["listOptions", "matMenu"], ["searchTermInput", ""], ["menu", "matMenu"], [1, "px-3"], [1, "title", "mb-3", "d-flex"], [1, "spacer"], ["mat-icon-button", "", 3, "matMenuTriggerFor", 4, "ngIf"], ["mat-menu-item", "", 3, "click"], ["appearance", "fill"], ["matInput", "", "placeholder", "Search by name", 3, "keyup"], ["mat-icon-button", "", "matSuffix", "", 3, "click", 4, "ngIf"], ["class", "p-2", 4, "ngIf"], ["mat-table", "", "matSort", "", "cdkDropList", "", 3, "cdkDropListDropped", "dataSource", "cdkDropListDisabled"], ["matColumnDef", "id"], ["mat-header-cell", "", "mat-sort-header", "", 4, "matHeaderCellDef"], ["mat-cell", "", 4, "matCellDef"], ["matColumnDef", "name"], ["matColumnDef", "sortOrder"], ["matColumnDef", "mappingsCount"], ["matColumnDef", "createdOn"], ["matColumnDef", "createdBy"], ["matColumnDef", "updatedOn"], ["matColumnDef", "updatedBy"], ["matColumnDef", "edit"], ["mat-header-cell", "", 4, "matHeaderCellDef"], ["mat-header-row", "", 4, "matHeaderRowDef"], ["mat-row", "", "cdkDrag", "", 4, "matRowDef", "matRowDefColumns"], ["showFirstLastButtons", "", 3, "page", "pageSizeOptions"], ["mat-fab", "", "color", "primary", "matTooltip", "New group", "queryParamsHandling", "merge", 1, "position-fixed", "b-0", "r-0", "mr-3", "mb-3", 3, "routerLink"], ["mode", "indeterminate", "class", "position-fixed l-0 b-0", 4, "ngIf"], ["mat-icon-button", "", 3, "matMenuTriggerFor"], ["mat-icon-button", "", "matSuffix", "", 3, "click"], [1, "p-2"], ["mat-header-cell", "", "mat-sort-header", ""], ["mat-cell", ""], ["mat-icon-button", "", "matTooltip", "Up", 3, "click", 4, "ngIf"], ["mat-icon-button", "", "matTooltip", "Down", 3, "click", 4, "ngIf"], ["mat-icon-button", "", "matTooltip", "Up", 3, "click"], ["mat-icon-button", "", "matTooltip", "Down", 3, "click"], ["mat-header-cell", ""], ["mat-menu-item", "", "queryParamsHandling", "merge", 3, "routerLink"], ["mat-header-row", ""], ["mat-row", "", "cdkDrag", ""], ["mode", "indeterminate", 1, "position-fixed", "l-0", "b-0"]], template: function AppGroupListComponent_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div", 3)(1, "div", 4)(2, "h1");
    \u0275\u0275text(3, "Groups");
    \u0275\u0275elementEnd();
    \u0275\u0275element(4, "span", 5);
    \u0275\u0275template(5, AppGroupListComponent_button_5_Template, 3, 1, "button", 6);
    \u0275\u0275elementStart(6, "mat-menu", null, 0)(8, "button", 7);
    \u0275\u0275listener("click", function AppGroupListComponent_Template_button_click_8_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.deleteUnmappedGroups());
    });
    \u0275\u0275elementStart(9, "mat-icon");
    \u0275\u0275text(10, "delete");
    \u0275\u0275elementEnd();
    \u0275\u0275text(11, " Delete Unmapped ");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(12, "button", 7);
    \u0275\u0275listener("click", function AppGroupListComponent_Template_button_click_12_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.reorder());
    });
    \u0275\u0275elementStart(13, "mat-icon");
    \u0275\u0275text(14, "reorder");
    \u0275\u0275elementEnd();
    \u0275\u0275text(15, " Reorder ");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(16, "button", 7);
    \u0275\u0275listener("click", function AppGroupListComponent_Template_button_click_16_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.toggleDragAndDrop());
    });
    \u0275\u0275elementStart(17, "mat-icon");
    \u0275\u0275text(18, "drag_indicator");
    \u0275\u0275elementEnd();
    \u0275\u0275text(19);
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(20, "mat-card")(21, "mat-form-field", 8)(22, "mat-label");
    \u0275\u0275text(23, "Search");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(24, "input", 9, 1);
    \u0275\u0275listener("keyup", function AppGroupListComponent_Template_input_keyup_24_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.applyFilter($event));
    });
    \u0275\u0275elementEnd();
    \u0275\u0275template(26, AppGroupListComponent_button_26_Template, 3, 0, "button", 10);
    \u0275\u0275elementEnd();
    \u0275\u0275template(27, AppGroupListComponent_mat_card_content_27_Template, 2, 1, "mat-card-content", 11);
    \u0275\u0275elementStart(28, "table", 12);
    \u0275\u0275listener("cdkDropListDropped", function AppGroupListComponent_Template_table_cdkDropListDropped_28_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onRowDrop($event));
    });
    \u0275\u0275elementContainerStart(29, 13);
    \u0275\u0275template(30, AppGroupListComponent_th_30_Template, 2, 0, "th", 14)(31, AppGroupListComponent_td_31_Template, 2, 1, "td", 15);
    \u0275\u0275elementContainerEnd();
    \u0275\u0275elementContainerStart(32, 16);
    \u0275\u0275template(33, AppGroupListComponent_th_33_Template, 2, 0, "th", 14)(34, AppGroupListComponent_td_34_Template, 2, 1, "td", 15);
    \u0275\u0275elementContainerEnd();
    \u0275\u0275elementContainerStart(35, 17);
    \u0275\u0275template(36, AppGroupListComponent_th_36_Template, 2, 0, "th", 14)(37, AppGroupListComponent_td_37_Template, 4, 3, "td", 15);
    \u0275\u0275elementContainerEnd();
    \u0275\u0275elementContainerStart(38, 18);
    \u0275\u0275template(39, AppGroupListComponent_th_39_Template, 2, 0, "th", 14)(40, AppGroupListComponent_td_40_Template, 2, 1, "td", 15);
    \u0275\u0275elementContainerEnd();
    \u0275\u0275elementContainerStart(41, 19);
    \u0275\u0275template(42, AppGroupListComponent_th_42_Template, 2, 0, "th", 14)(43, AppGroupListComponent_td_43_Template, 3, 4, "td", 15);
    \u0275\u0275elementContainerEnd();
    \u0275\u0275elementContainerStart(44, 20);
    \u0275\u0275template(45, AppGroupListComponent_th_45_Template, 2, 0, "th", 14)(46, AppGroupListComponent_td_46_Template, 2, 1, "td", 15);
    \u0275\u0275elementContainerEnd();
    \u0275\u0275elementContainerStart(47, 21);
    \u0275\u0275template(48, AppGroupListComponent_th_48_Template, 2, 0, "th", 14)(49, AppGroupListComponent_td_49_Template, 3, 4, "td", 15);
    \u0275\u0275elementContainerEnd();
    \u0275\u0275elementContainerStart(50, 22);
    \u0275\u0275template(51, AppGroupListComponent_th_51_Template, 2, 0, "th", 14)(52, AppGroupListComponent_td_52_Template, 2, 1, "td", 15);
    \u0275\u0275elementContainerEnd();
    \u0275\u0275elementContainerStart(53, 23);
    \u0275\u0275template(54, AppGroupListComponent_th_54_Template, 1, 0, "th", 24)(55, AppGroupListComponent_td_55_Template, 16, 4, "td", 15);
    \u0275\u0275elementContainerEnd();
    \u0275\u0275template(56, AppGroupListComponent_tr_56_Template, 1, 0, "tr", 25)(57, AppGroupListComponent_tr_57_Template, 1, 0, "tr", 26);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(58, "mat-paginator", 27);
    \u0275\u0275listener("page", function AppGroupListComponent_Template_mat_paginator_page_58_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onPaginate($event));
    });
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(59, "button", 28)(60, "mat-icon");
    \u0275\u0275text(61, "add");
    \u0275\u0275elementEnd()();
    \u0275\u0275template(62, AppGroupListComponent_mat_progress_bar_62_Template, 1, 0, "mat-progress-bar", 29);
    \u0275\u0275element(63, "router-outlet");
  }
  if (rf & 2) {
    \u0275\u0275advance(5);
    \u0275\u0275property("ngIf", ctx.dataSource.data.length > 0);
    \u0275\u0275advance(14);
    \u0275\u0275textInterpolate1(" ", ctx.dragAndDropEnabled ? "Disable" : "Enable", " Drag & Drop ");
    \u0275\u0275advance(2);
    \u0275\u0275classProp("collapse", ctx.noResultsFound);
    \u0275\u0275advance(5);
    \u0275\u0275property("ngIf", ctx.queryParams.searchTerm);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.message);
    \u0275\u0275advance();
    \u0275\u0275classProp("collapse", !(ctx.dataSource.data.length > 0));
    \u0275\u0275property("dataSource", ctx.dataSource)("cdkDropListDisabled", !ctx.dragAndDropEnabled);
    \u0275\u0275advance(28);
    \u0275\u0275property("matHeaderRowDef", ctx.displayedColumns);
    \u0275\u0275advance();
    \u0275\u0275property("matRowDefColumns", ctx.displayedColumns);
    \u0275\u0275advance();
    \u0275\u0275classProp("collapse", !(ctx.dataSource.data.length > 0));
    \u0275\u0275property("pageSizeOptions", \u0275\u0275pureFunction0(17, _c1));
    \u0275\u0275advance();
    \u0275\u0275property("routerLink", \u0275\u0275pureFunction0(18, _c2));
    \u0275\u0275advance(3);
    \u0275\u0275property("ngIf", ctx.isLoading);
  }
}, dependencies: [NgIf, RouterOutlet, RouterLink, CdkDropList, CdkDrag, MatFormField, MatLabel, MatSuffix, MatProgressBar, MatIconButton, MatFabButton, MatIcon, MatMenu, MatMenuItem, MatMenuTrigger, MatCard, MatCardContent, MatPaginator, MatTable, MatHeaderCellDef, MatHeaderRowDef, MatColumnDef, MatCellDef, MatRowDef, MatHeaderCell, MatCell, MatHeaderRow, MatRow, MatInput, MatSort, MatSortHeader, MatTooltip, DatePipe], encapsulation: 2 });
var AppGroupListComponent = _AppGroupListComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(AppGroupListComponent, { className: "AppGroupListComponent", filePath: "src\\app\\features\\group\\components\\app-group-list\\app-group-list.component.ts", lineNumber: 28 });
})();

// src/app/features/group/app-group-routing.module.ts
var routes = [
  {
    path: GROUP_ROUTES.base,
    component: AppGroupListComponent,
    children: [
      {
        path: GROUP_ROUTES.create,
        component: DummyComponent,
        data: {
          path: GROUP_ROUTES.create
        }
      },
      {
        path: GROUP_ROUTES.update,
        component: DummyComponent,
        data: {
          path: GROUP_ROUTES.update
        }
      }
    ]
  },
  { path: "**", redirectTo: GROUP_ROUTES.base }
];
var _GroupRoutingModule = class _GroupRoutingModule {
};
_GroupRoutingModule.\u0275fac = function GroupRoutingModule_Factory(t) {
  return new (t || _GroupRoutingModule)();
};
_GroupRoutingModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _GroupRoutingModule });
_GroupRoutingModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [RouterModule.forChild(routes), RouterModule] });
var GroupRoutingModule = _GroupRoutingModule;

// src/app/features/group/app-group.module.ts
var _GroupModule = class _GroupModule {
};
_GroupModule.\u0275fac = function GroupModule_Factory(t) {
  return new (t || _GroupModule)();
};
_GroupModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _GroupModule });
_GroupModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [
  CommonModule,
  GroupRoutingModule,
  DragDropModule,
  ReactiveFormsModule,
  MatFormFieldModule,
  MatProgressBarModule,
  MatButtonModule,
  MatIconModule,
  MatMenuModule,
  MatCardModule,
  MatFormFieldModule,
  MatPaginatorModule,
  MatTableModule,
  MatDialogModule,
  MatSelectModule,
  MatInputModule,
  MatSortModule,
  MatTooltipModule
] });
var GroupModule = _GroupModule;
export {
  GroupModule
};
//# sourceMappingURL=chunk-U6WLI2RV.js.map
