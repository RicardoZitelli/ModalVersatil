import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTipoProdutoComponent } from './edit-tipo-produto.component';

describe('EditTipoProdutoComponent', () => {
  let component: EditTipoProdutoComponent;
  let fixture: ComponentFixture<EditTipoProdutoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditTipoProdutoComponent]
    });
    fixture = TestBed.createComponent(EditTipoProdutoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
