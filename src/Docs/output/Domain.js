import { Union, Record } from "./.fable/fable-library.3.1.2/Types.js";
import { defaultPage, Page$reflection } from "./Router.js";
import { union_type, string_type, record_type, bool_type } from "./.fable/fable-library.3.1.2/Reflection.js";

export class Model extends Record {
    constructor(CurrentPage, ShowQuickView, ShowLoader) {
        super();
        this.CurrentPage = CurrentPage;
        this.ShowQuickView = ShowQuickView;
        this.ShowLoader = ShowLoader;
    }
}

export function Model$reflection() {
    return record_type("Domain.Model", [], Model, () => [["CurrentPage", Page$reflection()], ["ShowQuickView", bool_type], ["ShowLoader", bool_type]]);
}

export const ModelModule_init = new Model(defaultPage, false, false);

export class Msg extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["UrlChanged", "ToggleLoader", "SentToast"];
    }
}

export function Msg$reflection() {
    return union_type("Domain.Msg", [], Msg, () => [[["Item", Page$reflection()]], [], [["Item", string_type]]]);
}

