import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TipoProduto } from 'src/app/models/tipo-produto';
import { TipoProdutoService } from 'src/app/services/tipo-produto-servico';

@Component({
  selector: 'app-edit-tipo-produto',
  templateUrl: './edit-tipo-produto.component.html',
  styleUrls: ['./edit-tipo-produto.component.css']
})
export class EditTipoProdutoComponent implements OnInit{
  @Input() tipoProduto?: TipoProduto;
  @Output() tipoProdutoUpdated = new EventEmitter<TipoProduto[]>();

  constructor(private tipoProdutoService: TipoProdutoService){}

  ngOnInit(): void {
    
  }

  inserirTipoProduto(tipoProduto: TipoProduto){    
    if (tipoProduto.id != undefined && tipoProduto.id>0)
      this.tipoProdutoService.alterarTipoProduto(tipoProduto).subscribe((tipoProdutos)=>{
        this.tipoProdutoUpdated.emit(tipoProdutos)
      });
    else
      this.tipoProdutoService.adicionarTipoProduto(tipoProduto).subscribe((tipoProdutos)=>{
        this.tipoProdutoUpdated.emit(tipoProdutos);
      });      
  }
  
  excluirTipoProduto(tipoProduto: TipoProduto){
    if(tipoProduto.id != undefined && tipoProduto.id>0){         
      this.tipoProdutoService
        .excluirTipoProduto(tipoProduto.id)
        .subscribe((tipoProdutos) => {
          this.tipoProdutoUpdated.emit(tipoProdutos);
        });
    }
  }
}
