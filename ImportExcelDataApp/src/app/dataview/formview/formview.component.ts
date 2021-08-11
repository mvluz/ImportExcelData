import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { NgForm } from '@angular/forms';
import { forEach } from '@angular/router/src/utils/collection';
import { ToastrService } from 'ngx-toastr';
import { ImportService } from 'src/app/services/import.service';
import { baseURLFile } from 'src/app/shared/baseurl';

@Component({
  selector: 'app-formview',
  templateUrl: './formview.component.html',
  styleUrls: ['./formview.component.css']
})
export class FormViewComponent implements OnInit {

  public progress: number;
  public message: string;
  @Output() public onUploadFinished = new EventEmitter();

  constructor(public service:ImportService,
  private toastr: ToastrService,
  private http: HttpClient) { }

  fileToUpload: File | null = null;

  ngOnInit() {
  }

  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    this.http.post(baseURLFile, formData, {reportProgress: true, observe: 'events'})
      .subscribe(event => {
          
        
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Importação realizada com sucesso!';
          this.onUploadFinished.emit(event.body);
          console.log(event.body);     
        }
      });
  }
  
  
  resetForm(form:NgForm){
    form.form.reset();
    //this.service.formView = new Import();
  }
} 
