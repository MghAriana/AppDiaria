import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {

  const token = localStorage.getItem('token');

  console.log("Interceptor token:", token);

  if (token) {

    const requestClone = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });

    console.log("Request con auth:", requestClone);

    return next(requestClone);
  }

  return next(req);
};