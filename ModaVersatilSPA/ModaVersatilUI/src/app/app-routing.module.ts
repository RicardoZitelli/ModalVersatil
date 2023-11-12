import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { EditTipoProdutoComponent } from './components/edit-tipo-produto/edit-tipo-produto.component';
import { ListTipoProdutoComponent } from './components/list-tipo-produto/list-tipo-produto.component';

const routes: Routes = [
  { path: 'home', component: AppComponent },
  { path: 'edit-tipo-produto', component: EditTipoProdutoComponent},
  { path: 'list-tipo-produto', component: ListTipoProdutoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
