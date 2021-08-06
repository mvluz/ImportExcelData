import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { DataviewComponent } from './dataview/dataview.component';
import { FormviewComponent } from './dataview/formview/formview.component';

@NgModule({
  declarations: [
    AppComponent,
    DataviewComponent,
    FormviewComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
