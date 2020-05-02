import { Component, Injectable, ComponentRef, NgModuleRef, ReflectiveInjector } from '@angular/core';
import { Subject } from 'rxjs';
import { filter } from 'rxjs/operators'; 
import { Router, NavigationStart } from '@angular/router';

export class DialogRef{
    data:any;
    title:string;
    component:ComponentRef<any>;
    zIndex:number;
    
    private readonly _onClosedEvent = new Subject<any>();

    constructor(data:any, title:string){
        this.data = data;
        this.title = title;
    }

    OnClosed(){
        return this._onClosedEvent.asObservable();
    }

    CloseDialog(result?: any){
        this._onClosedEvent.next(result);
    }
}

@Injectable()
export class DialogService{
    modals: DialogRef[] = [];
    BASE_Z_INDEX = 1001;

    constructor(router:Router){
        router.events.pipe(filter(event => event instanceof NavigationStart)).subscribe(route=>{this.modals=[];})
    }

    OpenModal(module:NgModuleRef<any>, component:any, title:string, data:any){
        const dialogRef = new DialogRef(data, title);

        const injector = ReflectiveInjector.resolveAndCreate(
            [{
                provide: 'config', useValue: dialogRef
            }]);

        const factory = module.componentFactoryResolver.resolveComponentFactory(component);
        dialogRef.component = factory.create(injector);

        dialogRef.OnClosed().subscribe(() => {
            this.modals.pop();

            for (let i = 0; i < this.modals.length; i++) {
                this.modals[i].zIndex = this.BASE_Z_INDEX + i;
            }

            if (this.modals.length > 0){
                this.modals[this.modals.length - 1].zIndex = this.BASE_Z_INDEX + 100;
            }
        });

        dialogRef.zIndex = this.BASE_Z_INDEX + 100;

        for (let i = 0; i < this.modals.length; i++) {
            this.modals[i].zIndex = this.BASE_Z_INDEX + i;
        }

        this.modals.push(dialogRef);
        return dialogRef;
    }
}