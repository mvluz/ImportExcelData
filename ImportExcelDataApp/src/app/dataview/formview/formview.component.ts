import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {DomSanitizer} from '@angular/platform-browser';

import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ImportService } from 'src/app/services/import.service';
import { baseURL, baseURLImport } from 'src/app/shared/baseurl';
import { Import } from 'src/app/shared/import.model';

@Component({
  selector: 'app-formview',
  templateUrl: './formview.component.html',
  styleUrls: ['./formview.component.css']
})
export class FormViewComponent implements OnInit {

    constructor(public service:ImportService,
    private toastr: ToastrService,
    private http: HttpClient) { }


    ngOnInit() {
    }

    onSubmit(){

      this.service.postFormView().subscribe(
        res =>{
          console.log(res);
          //this.resetForm(form);
          this.toastr.success("Importado com sucesso","Importação de Excel")
        },
        err =>{ console.log(err);}
      );
    }

    resetForm(form:NgForm){
      form.form.reset();
      //this.service.formView = new Import();
    }
} 
