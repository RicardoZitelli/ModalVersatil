import { Component } from '@angular/core';
import { TipoProduto } from 'src/app/models/tipo-produto';
import { TipoProdutoService } from 'src/app/services/tipo-produto-servico';

@Component({
  selector: 'app-list-tipo-produto',
  templateUrl: './list-tipo-produto.component.html',
  styleUrls: ['./list-tipo-produto.component.css']
})
export class ListTipoProdutoComponent {
  title = 'ModaVersatilUI';
  tipoProdutos: TipoProduto[] = [];
  tipoProdutoEdit?: TipoProduto;

  constructor(private tipoProdutoService: TipoProdutoService){}

  ngOnInit() : void {
    this.tipoProdutoService.listarTipoProduto()
    .subscribe((result: TipoProduto[]) => {
      this.tipoProdutos = result;  
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
