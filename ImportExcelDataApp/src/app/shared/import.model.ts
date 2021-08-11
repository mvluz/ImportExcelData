import { Importitem } from "./importitem.model";
export class Import {
    importID: number = 0;
    createdON: string = '';
    fileLocal: string = ''; 
    itemsList: Importitem[];
}
