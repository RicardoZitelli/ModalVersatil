import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EditTipoProdutoComponent } from './components/edit-tipo-produto/edit-tipo-produto.component';
import { FormsModule } from '@angular/forms';
import { ListTipoProdutoComponent } from './components/list-tipo-produto/list-tipo-produto.component';

@NgModule({
  declarations: [
    AppComponent,
    EditTipoProdutoComponent,
    ListTipoProdutoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,    
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
