import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ImportService } from 'src/app/services/import.service';


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

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    let textTittleError = "Houve Erro na Importação de Excel";

    if (files.length === 0) {
      this.toastr.error("Selecione um arquivo", textTittleError)
      return;
    }

    formData.append('file', fileToUpload, fileToUpload.name);

    this.serviceImport.uploudPost(formData)
      .subscribe(
        () => {
          this.serviceImport.fileUploadError = [];
          this.toastr.success("Importado todos os registros com sucesso!", "Sucesso na Importação de Excel");
          this.serviceImport.resfreshDataView();
        },
        error => {
          this.serviceImport.fileUploadError = [];
          if (error.status === 400) {
            for (const i in error.error) {
              this.serviceImport.fileUploadError.push(error.error[i]);
            }
            this.toastr.error("Alguns registros não foram importados", textTittleError);
            this.serviceImport.resfreshDataView();
          } else {
            this.serviceImport.fileUploadError = [];
            this.toastr.error("Arquivo não suportado", textTittleError);
            this.serviceImport.resfreshDataView();
          }          
        }
      );
  }

}
