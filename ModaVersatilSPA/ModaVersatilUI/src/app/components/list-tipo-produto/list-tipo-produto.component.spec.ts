import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListTipoProdutoComponent } from './list-tipo-produto.component';

describe('ListTipoProdutoComponent', () => {
  let component: ListTipoProdutoComponent;
  let fixture: ComponentFixture<ListTipoProdutoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListTipoProdutoComponent]
    });
    fixture = TestBed.createComponent(ListTipoProdutoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
