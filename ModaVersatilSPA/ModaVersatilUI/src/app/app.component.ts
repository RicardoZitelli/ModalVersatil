import { Component } from '@angular/core';
import { TipoProduto } from './models/tipo-produto';
import { TipoProdutoService } from './services/tipo-produto-servico';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ModaVersatilUI';
  tipoProdutos: TipoProduto[] = [];
  tipoProdutoEdit?: TipoProduto;

  constructor(private tipoProdutoService: TipoProdutoService){}

  ngOnInit() : void {
    this.tipoProdutoService.listarTipoProduto()
    .subscribe((result: TipoProduto[]) => {
      this.tipoProdutos = result; console.log(result);
    });    
  }

  initNewTipoProduto(){
    this.tipoProdutoEdit = new TipoProduto();
  }

  atualizarTipoProdutoList(tipoProdutos: TipoProduto[]){
    this.tipoProdutos = tipoProdutos;
  }

  editarTipoProduto(tipoProduto: TipoProduto){
    this.tipoProdutoEdit = tipoProduto
  }   
}