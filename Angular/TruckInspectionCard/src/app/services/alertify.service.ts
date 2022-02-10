import { Injectable } from '@angular/core';
declare let alertify: any;
@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor() { }

  // tslint:disable-next-line: typedef
  public confirm(message: string, okCallback: () => any) {
    alertify.confirm(message, (e: any) => {
      if (e) {
        okCallback();
      } else { }
    });
  }

  // tslint:disable-next-line: typedef
  success(message: string) {
    alertify.success(message);
  }

  // tslint:disable-next-line: typedef
  error(message: string) {
    alertify.error(message);
  }

  // tslint:disable-next-line: typedef
  warning(message: string) {
    alertify.warning(message);
  }

  // tslint:disable-next-line: typedef
  message(message: string) {
    alertify.message(message);
  }

  // tslint:disable-next-line: typedef
  customAlert(sms: string) {
    alertify.alert().setting({
      movable: false,
      message: sms,
      transition: 'flipx'
    }).show();
  }
}
