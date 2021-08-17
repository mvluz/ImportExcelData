import { Injectable } from '@angular/core';
import { Import } from '../shared/import.model';
import { Importitem } from '../shared/importitem.model';
import { HttpClient } from '@angular/common/http';
import { baseURLImport, baseURLItem, baseURLFile } from '../shared/baseurl';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { FileUploadError } from '../shared/fileuploaderror';
import { BrowserDynamicTestingModule } from '@angular/platform-browser-dynamic/testing';
import { getLocaleDateTimeFormat } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class ImportService {

  constructor(private http: HttpClient,
    private toastr: ToastrService) { }

  dataView: Import[];
  dataViewItem: Importitem[];
  fileUploadError: FileUploadError[];
  menorDate = new Date();
  totalAmount = 0;
  totalItemsValues =0.0;

  resfreshDataView() {
    this.http.get(baseURLImport)
      .toPromise()
      .then(res => this.dataView = res as Import[])
  }

  getListDataViewItem(id: number): Observable<Importitem> {
    return this.http.get<Importitem>(`${baseURLItem}/${id}`);
  }

  uploudPost(formData): Observable<FileUploadError> {
    return this.http.post<FileUploadError>(baseURLFile, formData);
  }
}
