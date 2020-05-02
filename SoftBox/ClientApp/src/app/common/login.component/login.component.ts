import { Component, Inject } from '@angular/core';
import { DialogRef } from '../dialog/dialog.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls:['./login.component.scss']
})
export class LoginComponent {
  title = 'SoftBox';

  login: string = '';
  password: string = '';
  isAuthSuccess : boolean = true;

  constructor(@Inject('config') public config: DialogRef, 
              private authService : AuthService){

  }

  LogIn(){
    this.authService.LogIn(this.login, this.password).then((result =>
      {
        this.isAuthSuccess = result;
        if(result){
          this.config.CloseDialog();
        }
      }));
  }
}
