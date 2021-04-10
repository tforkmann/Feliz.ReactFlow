import { createObj, equals } from "./.fable/fable-library.3.1.2/Util.js";
import { ofArray, ofSeq, empty, singleton } from "./.fable/fable-library.3.1.2/List.js";
import { singleton as singleton_1, append, delay } from "./.fable/fable-library.3.1.2/Seq.js";
import { Msg } from "./Domain.js";
import { parseUrl, Page, getHref } from "./Router.js";
import { createElement } from "react";
import * as react from "react";
import { Helpers_combineClasses } from "./.fable/Feliz.Bulma.2.12.0/ElementBuilders.fs.js";
import { Interop_reactApi } from "./.fable/Feliz.1.41.0/Interop.fs.js";
import { overview as overview_1, installation } from "./views/Feliz.ReactFlow/FelizReactFlow.js";
import { overview } from "./views/Feliz.ReactFlow/FelizReactFlow.ExampleFlow.js";
import { join } from "./.fable/fable-library.3.1.2/String.js";
import { RouterModule_router } from "./.fable/Feliz.Router.3.8.0/Router.fs.js";

export function menuPart(model, dispatch) {
    let elms, elms_1;
    const item = (t, p) => {
        const isActive = equals(model.CurrentPage, p) ? singleton(["className", "is-active"]) : empty();
        const props = ofSeq(delay(() => append(isActive, delay(() => append(singleton_1(["onClick", (_arg1) => {
            dispatch(new Msg(2, t));
        }]), delay(() => append(singleton_1(["children", t]), delay(() => singleton_1(["href", getHref(p)])))))))));
        const children = singleton(createElement("a", createObj(Helpers_combineClasses("", props))));
        return createElement("li", {
            children: Interop_reactApi.Children.toArray(Array.from(children)),
        });
    };
    const elms_2 = ofArray([createElement("p", {
        className: "menu-label",
        children: "Feliz.ReactFlow",
    }), (elms = singleton(item("Overview", new Page(0))), createElement("ul", {
        className: "menu-list",
        children: Interop_reactApi.Children.toArray(Array.from(elms)),
    })), (elms_1 = ofArray([item("Installation", new Page(1)), item("Example Flow", new Page(2))]), createElement("ul", {
        className: "menu-list",
        children: Interop_reactApi.Children.toArray(Array.from(elms_1)),
    }))]);
    return createElement("aside", {
        className: "menu",
        children: Interop_reactApi.Children.toArray(Array.from(elms_2)),
    });
}

export function contentPart(model, dispatch) {
    const matchValue = model.CurrentPage;
    switch (matchValue.tag) {
        case 1: {
            return installation;
        }
        case 2: {
            return overview;
        }
        default: {
            return overview_1;
        }
    }
}

export function view(model, dispatch) {
    let elms, props_3, props, children;
    const render = createElement("div", {
        className: join(" ", ["container", "md:flex", "justify-center"]),
        children: Interop_reactApi.Children.toArray([(elms = singleton((props_3 = ofArray([["className", "is-ancestor"], ["children", Interop_reactApi.Children.toArray([(props = ofArray([["className", "is-2"], ["children", menuPart(model, dispatch)]]), createElement("div", createObj(Helpers_combineClasses("tile", props)))), (children = singleton(contentPart(model, dispatch)), createElement("div", {
            className: "tile",
            children: Interop_reactApi.Children.toArray(Array.from(children)),
        }))])]]), createElement("div", createObj(Helpers_combineClasses("tile", props_3))))), createElement("section", {
            className: "section",
            children: Interop_reactApi.Children.toArray(Array.from(elms)),
        }))]),
    });
    return RouterModule_router({
        onUrlChanged: (arg_1) => {
            dispatch(new Msg(0, parseUrl(arg_1)));
        },
        application: react.createElement(react.Fragment, {}, render),
    });
}

