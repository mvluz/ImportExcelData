import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ImportService } from '../services/import.service';

@Component({
  selector: 'app-dataview',
  templateUrl: './dataview.component.html',
  styleUrls: ['./dataview.component.css']
})
export class DataViewComponent implements OnInit {

  constructor(public serviceImport: ImportService,
    private toastr:ToastrService) { }

  ngOnInit() {
    this.serviceImport.resfreshDataView();
  }

  onDataViewItems(id:number){
    this.serviceImport.getListDataViewItem(id)
    .subscribe(
      res=>{
        this.serviceImport.dataViewItem=[];
        for (const i in res) {
          this.serviceImport.dataViewItem.push(res[i]);
        }
        
      }
    );
    console.log(this.serviceImport.dataViewItem);    
  }
}