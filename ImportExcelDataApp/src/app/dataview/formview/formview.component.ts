import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ImportService } from 'src/app/services/import.service';
import { FileUploadError } from 'src/app/shared/fileuploaderror';

@Component({
  selector: 'app-formview',
  templateUrl: './formview.component.html',
  styleUrls: ['./formview.component.css']
})
export class FormViewComponent implements OnInit {

  public progress: number;
  public message: string;

  @Output() public onUploadFinished = new EventEmitter();

  constructor(public serviceImport: ImportService,
    private toastr: ToastrService) { }

  fileToUpload: File | null = null;

  ngOnInit() {
  }

  public uploadFile = (files) => {
    var objError = [];
    var value = '';
    var obj = {};
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    this.serviceImport.uploudPost(formData)
      .subscribe(
        event => {
          this.serviceImport.fileUploadError = [];
          for (const i in event) {
            this.serviceImport.fileUploadError.push(event[i]);
          }
      });
  }


  resetForm(form: NgForm) {
    form.form.reset();
    //this.service.formView = new Import();
  }
}
