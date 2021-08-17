import { Component, OnInit } from '@angular/core';
import { ImportService } from '../services/import.service';

@Component({
  selector: 'app-dataview',
  templateUrl: './dataview.component.html',
  styleUrls: ['./dataview.component.css']
})
export class DataViewComponent implements OnInit {

  constructor(public serviceImport: ImportService) { }

  ngOnInit() {
    this.serviceImport.resfreshDataView();
  }

  onDataViewItems(id:number){
    this.serviceImport.getListDataViewItem(id)
    .subscribe(
      res=>{
        this.serviceImport.menorDate.setFullYear(9999);
        this.serviceImport.dataViewItem=[];
        this.serviceImport.totalAmount=0;
        this.serviceImport.totalItemsValues=0;

        for (const i in res) {
          this.serviceImport.dataViewItem.push(res[i]);          
        }

        for (const i of this.serviceImport.dataViewItem){     
          let dateToCompare = new Date(i.deliveryDate);
          if ( dateToCompare < this.serviceImport.menorDate){
            this.serviceImport.menorDate = dateToCompare;
          }
          this.serviceImport.totalAmount += i.amount;
          this.serviceImport.totalItemsValues += (i.amount * i.unitaryValue);
        }

      }
    );  
  }
}