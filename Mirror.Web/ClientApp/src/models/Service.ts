import { IEntity } from "./IEntity";
import { Vendor } from "./Vendor";

export class Service implements IEntity<number> {
    id: number;
    name: string;
    description: string;
    vendors: Vendor[];
}