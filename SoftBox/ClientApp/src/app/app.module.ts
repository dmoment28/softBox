import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './common/login.component/login.component';
import { DialogComponent } from './common/dialog/dialog.component';
import { DialogCreator } from './common/dialog/dialog.component.creator';
import { DialogService } from './common/dialog/dialog.service';
import { TokenInterceptor } from './common/services/token.interceptor';
import { AuthService } from './common/services/auth.service';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' }
];

export function initApp(authService :AuthService){
  return () => authService.Init();
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DialogComponent,
    DialogCreator
  ],
  entryComponents:[
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes),
    HttpClientModule
  ],
  providers: [DialogService,
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true, deps:[AuthService] },
    { provide: APP_INITIALIZER, useFactory: initApp, deps: [AuthService], multi: true}],
  bootstrap: [AppComponent],
  exports: [RouterModule]
})
export class AppModule { }



