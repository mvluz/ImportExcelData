import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ImportService } from 'src/app/services/import.service';
import { Import } from 'src/app/shared/import.model';

@Component({
  selector: 'app-formview',
  templateUrl: './formview.component.html',
  styleUrls: ['./formview.component.css']
})
export class FormViewComponent implements OnInit {

  constructor(public service:ImportService,
    private toastr: ToastrService) { }

  ngOnInit() {
  }

  onSubmit(form:NgForm){
    this.service.postFormView().subscribe(
      res =>{
        this.resetForm(form);
        this.toastr.success("Importado com sucesso","Importação de Excel")
      },
      err =>{ console.log(err);}
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formView = new Import();
  }
}
