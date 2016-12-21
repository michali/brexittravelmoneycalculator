import { Directive,Attribute } from '@angular/core';
import { AbstractControl, ValidatorFn, Validator, FormControl, NG_VALIDATORS } from '@angular/forms';

@Directive({
    selector: '[ddInvalidValue][ngModel]',
    providers: [
        { provide: NG_VALIDATORS, useExisting: DropdownInvalidValueDirective, multi: true }
    ]
})

export class DropdownInvalidValueDirective implements Validator {

    validate(c: AbstractControl) : { [key: string]: any }  {
        if (c.get()) {
            return {
                ddInvalidValue: {value:false}
            };
        }
        return null;
    }
}