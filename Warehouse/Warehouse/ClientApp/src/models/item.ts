import { User } from "./user";
import { Dimension } from "./dimension";
import { WarehouseFile } from "./warehouseFile";
import { WarehouseLocation } from "./warehouseLocation";

export class Item {
  id: number;
  serialNumber: string;
  name: string;
  weight: number;
  description: string;
  createdAt: Date;
  modifiedAt: Date;
  location: WarehouseLocation;
  dimension: Dimension;
  file: WarehouseFile;
  user: User;
}
