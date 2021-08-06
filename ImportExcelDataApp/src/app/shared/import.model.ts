import { BrowserDynamicTestingModule } from "@angular/platform-browser-dynamic/testing";
import * as internal from "assert";
import { Importitem } from "./importitem.model";
export class Import {
    importID: number;
    createdON: string;
    fileLocal: string;
    itemsList: Importitem[];
}
