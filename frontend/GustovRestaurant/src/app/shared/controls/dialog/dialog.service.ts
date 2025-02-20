import {
  ApplicationRef,
  ComponentRef,
  EnvironmentInjector,
  Injectable,
  InjectionToken,
  TemplateRef,
  Type,
  ViewContainerRef,
  createComponent,
} from '@angular/core';
import { GustovDialogComponent } from './dialog.component';
import { DialogConfigInterface } from './models/dialog-config.interface';
import { Observable } from 'rxjs';
import { DialogActionInterface } from './models/dialog-action.interface';

export const Gustov_DIALOG_DATA = new InjectionToken<any>('GustovDialogData');

@Injectable({
  providedIn: 'root',
})
export class GustovDialogService implements DialogActionInterface {
  newModalComponent!: ComponentRef<GustovDialogComponent>;
  dialogConfig!: DialogConfigInterface | undefined;

  constructor(
    private appRef: ApplicationRef,
    private injector: EnvironmentInjector
  ) {
    console.log('CONSTRUCTOR SERVICE');
  }

  afterClosed(): Observable<any> {
    return this.newModalComponent.instance.afterClosed$;
  }

  open<C>(
    vcrOrComponent: ViewContainerRef | Type<C>,
    param2?: TemplateRef<Element> | DialogConfigInterface,
    dialogConfig?: DialogConfigInterface
  ): DialogActionInterface {
    if (vcrOrComponent instanceof ViewContainerRef) {
      this.openWithTemplate(vcrOrComponent, param2 as TemplateRef<Element>);
      this.dialogConfig = dialogConfig;
    } else {
      this.dialogConfig = param2 as DialogConfigInterface | undefined;
      this.openWithComponent(vcrOrComponent);
    }

    return this;
  }

  private openWithTemplate(
    vcr: ViewContainerRef,
    content: TemplateRef<Element>
  ) {
    vcr.clear();

    const innerContent = vcr.createEmbeddedView(content);

    this.newModalComponent = vcr.createComponent(GustovDialogComponent, {
      environmentInjector: this.injector,
      projectableNodes: [innerContent.rootNodes],
    });
  }

  private openWithComponent(component: Type<unknown>) {
    let newComponent = createComponent(component, {
      environmentInjector: this.injector,
    });

    this.newModalComponent = createComponent(GustovDialogComponent, {
      environmentInjector: this.injector,
      projectableNodes: [[newComponent.location.nativeElement]],
    });

    document.body.appendChild(this.newModalComponent.location.nativeElement);

    // Attach views to the changeDetection cycle
    this.appRef.attachView(newComponent.hostView);
    this.appRef.attachView(this.newModalComponent.hostView);
  }

  close(returnValue: any = null) {
    this.newModalComponent.instance.close(returnValue);
  }
}
