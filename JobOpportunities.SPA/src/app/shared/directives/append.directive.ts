import {
  Directive,
  ElementRef,
  Input,
  OnChanges,
  Renderer2,
  SimpleChanges,
} from '@angular/core';
import { CompanyAgent } from 'src/app/common/models/company-agent';

@Directive({
  selector: '[appAppend]',
})
export class AppendDirective implements OnChanges {
  @Input('appAppend') companyAgentParam: CompanyAgent;

  constructor(private element: ElementRef, private renderer: Renderer2) {}

  ngOnChanges(changes: SimpleChanges) {
    if (changes['companyAgentParam'].currentValue) {
      const accNum = changes['companyAgentParam'].currentValue.offers.length;
      const span = this.renderer.createElement('span');
      const text = this.renderer.createText(` (${accNum}) ofertas`);
      this.renderer.appendChild(span, text);
      this.renderer.appendChild(this.element.nativeElement, span);
    }
  }
}
