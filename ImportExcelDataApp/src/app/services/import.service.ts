import { Injectable } from '@angular/core';
import { Import } from '../shared/import.model';
import { Importitem } from '../shared/importitem.model';
import { HttpClient } from '@angular/common/http';
import { baseURLImport, baseURLItem, baseURLFile } from '../shared/baseurl';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ImportService {

  constructor(private http:HttpClient,
    private toastr:ToastrService) { }
  
  dataView: Import[]; 
  dataViewItem: Importitem[] = [];
  
  resfreshDataView(){
    this.http.get(baseURLImport)
    .toPromise()
    .then(res => this.dataView = res as Import[]);
  }

  getListDataViewItem(id:number):Observable<Importitem>{
    return this.http.get<Importitem>(`${baseURLItem}/${id}`);
  }

}
