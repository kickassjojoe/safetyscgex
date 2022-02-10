import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import { Vehicle } from './../shared/vehicle.model';
import { TruckInspectionCategory } from './../shared/truckinspection.model';
import { Employee } from '../shared/employee.model';
import { } from '../shared/truckinspection.model';

@Injectable({
  providedIn: 'root'
})
export class TruckinspectionService {
  // localhost url
  // empUrl = 'https://localhost:44396/api/employeeapi';
  // vehicleUrl = 'https://localhost:44396/api/vehicleapi';
  // categoryUrl = 'https://localhost:44396/api/TruckInspectionCategoryApi';
  // cateItemUrl = '';
  // addUrl = 'https://localhost:44396/api/TruckInspectionCardApi/addcard';
  // uploadUrl = 'https://localhost:44396/api/TruckInspectionCardApi/upload';

  // azure website url
  empUrl = 'https://scgexpresssafety.azurewebsites.net/api/employeeapi';
  vehicleUrl = 'https://scgexpresssafety.azurewebsites.net/api/vehicleapi';
  categoryUrl = 'https://scgexpresssafety.azurewebsites.net/api/TruckInspectionCategoryApi';
  cateItemUrl = '';
  addUrl = 'https://scgexpresssafety.azurewebsites.net/api/TruckInspectionCardApi/addcard';
  uploadUrl = 'https://scgexpresssafety.azurewebsites.net/api/TruckInspectionCardApi/upload';

  constructor(private http: HttpClient) { }

  public employees(): Observable<Employee> {
    return this.http.get<Employee>(this.empUrl);
  }

  public vehicles(): Observable<Vehicle[]> {
    return this.http.get<Vehicle[]>(this.vehicleUrl);
  }

  public categories(): Observable<TruckInspectionCategory[]> {
    return this.http.get<TruckInspectionCategory[]>(this.categoryUrl);
  }

  public addCard(formValue: any): Observable<any> {
    const myheaders = { 'Content-Type': 'application/json' };
    const body = {
      employeeCode: formValue.employeeCode,
      employeeName: formValue.employeeName,
      startOdometer: formValue.startOdometer,
      vehicle: formValue.vehicle,
      userData: formValue.userData,
      files: formValue.file
    };
    return this.http.post(this.addUrl, body, {
      headers: myheaders
    }).pipe(
      // retry(1),
      catchError(this.handleError)
    );
  }

  public uploadFile(formData: FormData): Observable<any> {
    formData.forEach(x => {
      console.log(x);
    });

    return this.http.post(this.uploadUrl, formData, {
      reportProgress: true,
      observe: 'events'
    }).pipe(
      retry(1),
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse): any {
    return throwError(error);
  }
}
