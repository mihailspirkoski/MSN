import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthenticationService } from './authentication/authentication.service';

export const tokenInterceptorInterceptor: HttpInterceptorFn = (req, next) => {


  let authService = inject(AuthenticationService);
  const token = authService.getToken();

  const authReq = req.clone({
    setHeaders: {
      Authorization: `Bearer ${token}`
    }
  });

  return next(authReq);
};
