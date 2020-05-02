import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/user';


@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private static user: User;
    constructor(private httpClient: HttpClient) {

    }

    LogIn(login: string, password: string): Promise<boolean> {
        return this.httpClient.post("api/accounts/login", { Login: login, Password: password }).toPromise().then((result: User) => {
            AuthService.user = result;
            this.SetupToken(result.token);
            return true;
        },
            (result: any) => { return false });
    }

    GetToken() {
        if (AuthService.user) {
            return AuthService.user.token;
        }
        return localStorage.getItem("apiToken");
    }

    IsUserLogedIn() {
        if(AuthService.user){
            return AuthService.user;
        }
        return localStorage.getItem("apiToken");
    }

    SetupToken(token: string){
        localStorage.setItem("apiToken", token);
    }

    Init(){
        return this.httpClient.get("api/accounts/GetCurrentUser").toPromise().then((res: User) => {
            AuthService.user = res;
            if( res != null ){
                AuthService.user.token = localStorage.getItem("apiToken");
            }
        });
    }
}