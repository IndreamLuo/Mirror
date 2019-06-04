import { IEntity } from "./IEntity";

export class Vendor implements IEntity<number> {
    id: number;
    url: string;
}