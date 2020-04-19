import { Component, ViewChild, ViewContainerRef, Input, OnInit } from '@angular/core';
import { DialogRef } from './dialog.service';

@Component({
    selector: 'app-dialog-creator',
    template: `<ng-container #container></ng-container>`
})
export class DialogCreator implements OnInit{
    @ViewChild('container', { static:true, read: ViewContainerRef}) container: ViewContainerRef;
    @Input() editor : DialogRef;

    constructor(){

    }

    ngOnInit(){
        this.container.insert(this.editor.component.hostView);
    }
}