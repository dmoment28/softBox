import { Component, NgModuleRef } from '@angular/core';
import { DialogService } from './common/dialog/dialog.service';
import { LoginComponent } from './common/login.component/login.component';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'SoftBox';
  constructor(private moduleRef: NgModuleRef<any>, private dialogService: DialogService, private httpClient:HttpClient) {

  }

  OpenLogIn() {
    let dialog = this.dialogService.OpenModal(this.moduleRef, LoginComponent, 'Log In', null);
    dialog.OnClosed().subscribe((result) => {
      console.log(result);
      this.httpClient.get("api/accounts/test").subscribe((res) => {
        console.log(res);
      });
    });
  }
}
