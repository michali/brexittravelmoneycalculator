import { Directive,Attribute } from '@angular/core';
import { AbstractControl, ValidatorFn, Validator, FormControl, NG_VALIDATORS } from '@angular/forms';

@Directive({
    selector: '[ddInvalidValue][ngModel]',
    providers: [
        { provide: NG_VALIDATORS, useExisting: DropdownInvalidValueDirective, multi: true }
    ]
})

export class DropdownInvalidValueDirective implements Validator {

    constructor( @Attribute('ddInvalidValue') public ddInvalidValue: any) {} 

    validate(c: AbstractControl) : { [key: string]: any }  {
        if (c.value == this.ddInvalidValue) {
            return {
                ddInvalidValue: {value:false}
            };
        }
        return null;
    }
}