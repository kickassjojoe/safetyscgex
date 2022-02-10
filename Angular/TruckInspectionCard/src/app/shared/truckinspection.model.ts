export class TruckInspecionCard {
  truckInspecionCardId: number;
  employeeCode: string;
  employeeName: string;
  vehicleId: number;
  plateNumber: string;
  inspectionDate: Date;
  startOdometer: number;
  finishedOdometer: number;
  truckInspecionCardDetails: TruckInspecionCardDetail[];
}

export class TruckInspecionCardDetail {
  id: number;
  truckInspectionCardId: number;
  truckInspectionItemId: number;
  isNormal: boolean;
  picturePath: string;
  remark: string;
}

export class TruckInspectionCategory {
  truckInspectionCategoryId: number;
  name: string;
  truckInspectionItems: TruckInspectionItem[];
  truckInspectionCards: any[];
  isDeleted: boolean;
  deletedDate?: any;
  createdDate: Date;
  createdBy?: any;
  modified?: any;
  modifiedBy?: any;
}

export class TruckInspectionItem {
  truckInspectionCategory: TruckInspectionCategory;
  truckInspectionItemId: number;
  name: string;
  truckInspectionCategoryId: number;
  isDeleted: boolean;
  deletedDate?: any;
  createdDate: Date;
  createdBy?: any;
  modified?: any;
  modifiedBy?: any;
  isMust: boolean;
  isFirstAndFifteenth: boolean;
}
