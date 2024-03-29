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

  alterarTipoProduto(tipoProduto: TipoProduto){    
    if (tipoProduto.id != undefined && tipoProduto.id>0)
      this.tipoProdutoService.alterarTipoProduto(tipoProduto).subscribe((tipoProdutos)=>{
        this.tipoProdutoUpdated.emit(tipoProdutos)
        this.limparCampos();
      });
    else
      this.tipoProdutoService.adicionarTipoProduto(tipoProduto).subscribe((tipoProdutos)=>{
        this.tipoProdutoUpdated.emit(tipoProdutos);
        this.limparCampos();
      });      
  }
  
  excluirTipoProduto(tipoProduto: TipoProduto){        
    if(confirm('tem certeza que deseja excluir o tipo do produto?'))
      if(tipoProduto.id != undefined && tipoProduto.id>0){         
        this.tipoProdutoService.excluirTipoProduto(tipoProduto.id).subscribe((tipoProdutos) => {
            this.tipoProdutoUpdated.emit(tipoProdutos);
            this.limparCampos();
          });
      }
  }

  limparCampos(){
    this.tipoProduto = new TipoProduto();
  }
}
