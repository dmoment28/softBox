import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from "@angular/common/http";
import { Observable } from "rxjs";
import { AuthService } from "./auth.service";

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
    constructor(private authService: AuthService) {

    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if(this.authService.IsUserLogedIn())
        {
        request = request.clone({
            setHeaders: { Authorization: `Bearer ${this.authService.GetToken()}`}
        });
        // request.headers.append("Authorization", this.authService.GetToken());   
        }
        return next.handle(request);
    }
}