import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { TipoProduto } from '../models/tipo-produto';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})

export class TipoProdutoService {
    private urlAdicionarTipoProdutos = "TipoProduto/AdicionarTipoProdutoAsync";
    private urlAlterarTipoProdutos = "TipoProduto/AlterarTipoProdutoAsync";
    private urlExcluirTipoProdutos = "TipoProduto/ExcluirTipoProdutoAsync";
    private urlObterTipoProdutos = "TipoProduto/ObterTipoProdutoAsync";    
    private urlListarTipoProdutos = "TipoProduto/ListarTipoProdutoAsync";    
    
    constructor(private http: HttpClient){ }
    
    public adicionarTipoProduto(tipoProduto: TipoProduto): Observable<TipoProduto[]> {                
        let url = `${environment.apiUrl}/${this.urlAdicionarTipoProdutos}`;        
        return this.http.post<TipoProduto[]>(url,tipoProduto);            
    }

    public alterarTipoProduto(tipoProduto: TipoProduto): Observable<TipoProduto[]> {                
        let url = `${environment.apiUrl}/${this.urlAlterarTipoProdutos}`;
        return this.http.put<TipoProduto[]>(url,tipoProduto);        
    }

    public excluirTipoProduto(id: number): Observable<TipoProduto[]> {           
        let url = `${environment.apiUrl}/${this.urlExcluirTipoProdutos}/${id}`;
        return this.http.delete<TipoProduto[]>(url);            
    }

    public listarTipoProduto(): Observable<TipoProduto[]> {                
        return this.http.get<TipoProduto[]>(`${environment.apiUrl}/${this.urlListarTipoProdutos}`);    
    }

    public obterTipoProduto(id: number): Observable<TipoProduto> {                
        return this.http.get<TipoProduto>(`${environment.apiUrl}/${this.urlObterTipoProdutos}/${id}`);    
    }    
}