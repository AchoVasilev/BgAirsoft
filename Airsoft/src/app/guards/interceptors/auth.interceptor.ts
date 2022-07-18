import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { Observable, tap } from "rxjs";
import { UserService } from "src/app/services/user/user.service";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    constructor(private userService: UserService, private router: Router, private toastr: ToastrService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (this.userService.isAuthenticated()) {
            const clonedReq = req.clone({
                headers: req.headers.set('Authorization', 'Bearer ' + localStorage.getItem('token'))
            });

            return next.handle(clonedReq).pipe(
                tap({
                    next: () => { },
                    error: (err) => { 
                        if (err.status == 401) {
                            this.toastr.error("Трябва да влезете с акаунта си!");
                            localStorage.removeItem('token');

                            setTimeout(() => {
                                this.router.navigate(['/user/login']);
                            }, 500);
                        }
                    }
                })
            )
        } else {
            return next.handle(req.clone());
        }
    }

}