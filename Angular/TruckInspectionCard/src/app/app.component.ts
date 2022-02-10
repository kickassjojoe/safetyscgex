import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { FormBuilder, Validators, FormArray, FormGroup, FormControl } from '@angular/forms';

import { faFileAlt } from '@fortawesome/free-regular-svg-icons';
import { Select2OptionData } from 'ng-Select2';
import { Ng2ImgMaxService } from 'ng2-img-max';
import { AlertifyService } from './services/alertify.service';

import { TruckinspectionService } from './services/truckinspection.service';
import { Vehicle } from './shared/vehicle.model';
import { TruckInspecionCard, TruckInspectionCategory } from './shared/truckinspection.model';
import { Employee } from './shared/employee.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'TruckInspectionCard';
  cardForm: FormGroup;
  card = new TruckInspecionCard();

  empSub: Subscription;
  vehicleSub: Subscription;
  imgSub: Subscription;
  uploadFileSub: Subscription;
  catSub: Subscription;

  public faFileAlt = faFileAlt;
  public exampleData: Select2OptionData[] = [];
  public employee: Employee;
  public vehicles: Vehicle[] = [];
  public vehicleId: number;
  public categories: TruckInspectionCategory[] = [];
  public startPosition: number[] = [0];
  public selectedFiles: File[] = [];
  public uploadedImage: File;
  public numberOfTicks = 0;
  public isLoading = false;

  constructor(private service: TruckinspectionService,
    private fb: FormBuilder,
    private ng2ImgMax: Ng2ImgMaxService,
    private ref: ChangeDetectorRef,
    private alertify: AlertifyService) {

    setInterval(() => {
      this.numberOfTicks++;
      // require view to be updated
      this.ref.markForCheck();
    }, 500);

    this.cardForm = this.fb.group({
      employeeCode: ['', Validators.required],
      employeeName: ['', Validators.required],
      startOdometer: ['', [Validators.required, Validators.min(1), Validators.max(999999)]],
      vehicle: ['', Validators.required],
      userData: this.fb.array([])
    });
  }

  ngOnDestroy(): void {
    this.empSub.unsubscribe();
    this.vehicleSub.unsubscribe();
    this.imgSub.unsubscribe();
    this.uploadFileSub.unsubscribe();
    this.catSub.unsubscribe();
  }

  ngOnInit(): void {
    this.getEmployees();
    this.getVehicle();
    this.getCategory();

  }

  public get userData(): FormArray {
    return this.cardForm.get('userData') as FormArray;
  }

  newUserData(catid: number, truckInspectionId: number, truckInspectionName: string, ismust: boolean): FormGroup {
    return this.fb.group({
      categoryId: new FormControl(catid),
      truckInspectionId: new FormControl(truckInspectionId),
      truckInspectionName: new FormControl(truckInspectionName),
      isMust: new FormControl(ismust),
      isNormal: new FormControl(''),
      remark: new FormControl(''),
      file: new FormControl()
    });
  }

  addUserData(catid: number, truckInspectionId: number, truckInspectionName: string, ismust: boolean): void {
    this.userData.push(this.newUserData(catid, truckInspectionId, truckInspectionName, ismust));
  }

  private getEmployees(): void {
    this.empSub = this.service.employees().subscribe(x => {
      this.employee = x;
      this.card.employeeCode = this.employee.employeeCode;
      this.card.employeeName = this.employee.nameTH;
      console.log(x);
    }, error => console.log(error),
      () => console.log('Employee Done'));
  }

  private getVehicle(): void {
    this.vehicleSub = this.service.vehicles().subscribe(x => {
      this.vehicles = x;
      console.log(x);
    }, error => console.log(error),
      () => console.log('Vehicle Done'));
  }

  private getCategory(): void {
    this.isLoading = true;
    const loop = [];
    this.catSub = this.service.categories().subscribe(x => {
      this.categories = x;
      console.log(x);
      this.categories.forEach((e, i) => {
        const position = this.startPosition[i];
        const n = e.truckInspectionItems.length;
        const catid = e.truckInspectionCategoryId;
        loop.push(n);
        this.startPosition.push(position + n);
        e.truckInspectionItems.forEach((value, index) => {
          const truckInspectionId = value.truckInspectionItemId;
          const truckInspectionName = value.name;
          const ismust = value.isMust;
          this.addUserData(catid, truckInspectionId, truckInspectionName, ismust);
        });
      });
    }, error => {
      console.log(error);
      this.isLoading = false;
    },
      () => {
        console.log('Category Done');
        this.isLoading = false;
      });

  }

  public onFileSelected(event: any, categoryId: number, truckInspectionId: number): void {
    const file = event.target.files[0] as File;
    // verify file type
    if (file.type === 'image/jpeg' || file.type === 'image/png') {
      // compress image
      this.imgSub = this.ng2ImgMax.resizeImage(file, 400, 300).subscribe(
        result => {
          this.uploadedImage = result; // new File([result], result.name);
          // rename image
          const blob = this.uploadedImage.slice(0, this.uploadedImage.size, 'image/png');
          // const newFile = new File([blob], 'image_' + categoryId + '_' + truckInspectionId, { type: 'image/png' });
          this.uploadedImage = new File([blob], 'image_' + categoryId + '_' + truckInspectionId, { type: 'image/png' });

          this.selectedFiles.push(this.uploadedImage);
        },
        error => {
          console.log(error);
        }, () => {
        }
      );
    } else {
      alert('This file will not save.');
    }
    console.log(this.selectedFiles);
  }

  public onSubmit(FormValue: any): void {
    this.isLoading = true;
    let cardId = '';
    // const vehicleId = FormValue.vehicle;
    const formData = new FormData();
    for (const f of this.selectedFiles) {
      formData.append('files', f);
    }
    this.service.addCard(FormValue).subscribe(
      res => {
        cardId = res.truckInspectionCardId;
        formData.append('cardId', res.truckInspectionCardId);
        formData.append('vehicle', res.vehicleId);
      },
      error => {
        this.isLoading = false;
        this.alertify.error(error.error.message);
        console.log(error);
        return false;
      }
      , () => {
        this.uploadFileSub = this.service.uploadFile(formData).subscribe(
          res => {
            console.log('upload file is ');
            console.log(res);
          }, error => console.log(error.message)
          , () => {
            this.isLoading = false;
            this.getVehicle();
            this.alertify.customAlert('บันทึกเรียบร้อย card id : ' + cardId);
            this.userData.controls.forEach(x => x.get('isNormal').reset());
            this.userData.controls.forEach(x => x.get('remark').reset());
            this.userData.controls.forEach(x => x.get('file').reset());
            this.cardForm.get('startOdometer').reset();
            this.card.startOdometer = null;
            this.selectedFiles = [];
          }
        );
      }
    );
  }
}

