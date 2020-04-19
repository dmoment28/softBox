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
            return true;
        },
            (result: any) => { return false });
    }

    GetToken() {
        if (AuthService.user) {
            return AuthService.user.token;
        }
        return "";
    }

    IsUserLogedIn() {
        return AuthService.user;
    }
}