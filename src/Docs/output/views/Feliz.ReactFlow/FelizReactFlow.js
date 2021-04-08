import { createElement } from "react";
import { Interop_reactApi } from "../../.fable/Feliz.1.40.1/Interop.fs.js";
import { ofArray } from "../../.fable/fable-library.3.1.2/List.js";
import { funcToTuple, reactFlow } from "../../Feliz.ReactFlow/Interop.js";
import { ArrowHead, ArrowHead__get_Value, EdgeType, EdgeType__get_Value, NodeType, NodeType__get_Value } from "../../Feliz.ReactFlow/Types.js";
import { createObj } from "../../.fable/fable-library.3.1.2/Util.js";
import { some } from "../../.fable/fable-library.3.1.2/Option.js";
import { installationView, fixDocsView } from "../../Shared.js";

export const overview = (() => {
    let elms, props_6, props_8, props_10, props_12, props_15, props_18, props_21, elms_2, children_2;
    const children_5 = ofArray([(elms = ofArray(["Feliz.ReactFlow - Documentation", createElement("a", {
        href: "https://www.nuget.org/packages/Feliz.ReactFlow/",
        children: Interop_reactApi.Children.toArray([createElement("img", {
            src: "https://img.shields.io/nuget/v/Feliz.ReactFlow.svg?style=flat",
        })]),
    })]), createElement("h1", {
        className: "title is-1",
        children: Interop_reactApi.Children.toArray(Array.from(elms)),
    })), createElement("h2", {
        className: "subtitle is-2",
        children: Interop_reactApi.Children.toArray(["Feliz bindings for ReactFlow."]),
    }), createElement("hr", {}), Interop_reactApi.createElement(reactFlow, {
        elements: [(props_6 = ofArray([["id", "1"], ["type", NodeType__get_Value(new NodeType(0))], ["data", {
            label: "Erdgas Einsatz",
        }], ["style", {
            background: "yellow",
            color: "#332",
            border: "1px solid #222138",
            width: 180,
        }], ["position", {
            x: 20,
            y: 5,
        }]]), Object.assign({}, (() => ({})), createObj(props_6))), (props_8 = ofArray([["id", "2"], ["type", NodeType__get_Value(new NodeType(2))], ["data", {
            label: "CityCube",
        }], ["style", {
            background: "#2e88c9",
            color: "white",
            border: "1px solid #222138",
            width: 180,
        }], ["position", {
            x: 250,
            y: 5,
        }]]), Object.assign({}, (() => ({})), createObj(props_8))), (props_10 = ofArray([["id", "3"], ["type", NodeType__get_Value(new NodeType(1))], ["data", {
            label: "Strom Absatz",
        }], ["style", {
            background: "lightblue",
            color: "#333",
            border: "1px solid #222138",
            width: 180,
        }], ["position", {
            x: 100,
            y: 100,
        }]]), Object.assign({}, (() => ({})), createObj(props_10))), (props_12 = ofArray([["id", "4"], ["type", NodeType__get_Value(new NodeType(1))], ["data", {
            label: "Wärme Absatz",
        }], ["style", {
            background: "red",
            color: "white",
            border: "1px solid #222138",
            width: 180,
        }], ["position", {
            x: 100,
            y: 100,
        }]]), Object.assign({}, (() => ({})), createObj(props_12))), (props_15 = ofArray([["id", "e1-2"], ["source", "1"], ["target", "2"], ["animated", false], ["label", "100 MWh"], ["type", EdgeType__get_Value(new EdgeType(3))], ["arrowHeadType", ArrowHead__get_Value(new ArrowHead(1))], ["style", {
            stroke: "yellow",
        }], ["labelStyle", {
            fill: "black",
            fontWeight: 700,
        }]]), Object.assign({}, (() => ({})), createObj(props_15))), (props_18 = ofArray([["id", "e2-3"], ["source", "2"], ["target", "3"], ["animated", true], ["label", "50 MWh"], ["type", EdgeType__get_Value(new EdgeType(3))], ["arrowHeadType", ArrowHead__get_Value(new ArrowHead(1))], ["style", {
            stroke: "blue",
        }], ["labelStyle", {
            fill: "blue",
            fontWeight: 700,
        }]]), Object.assign({}, (() => ({})), createObj(props_18))), (props_21 = ofArray([["id", "e2-4"], ["source", "2"], ["target", "4"], ["animated", true], ["label", "55 MWh"], ["type", EdgeType__get_Value(new EdgeType(3))], ["arrowHeadType", ArrowHead__get_Value(new ArrowHead(1))], ["style", {
            stroke: "red",
        }], ["labelStyle", {
            fill: "red",
            fontWeight: 700,
        }]]), Object.assign({}, (() => ({})), createObj(props_21)))],
        onConnectStart: funcToTuple((tupledArg) => {
            console.log(some(tupledArg[1]));
            window.alert(some("You clicked me!"));
        }),
        onNodeDragStop: funcToTuple((tupledArg_1) => {
            console.log(some(tupledArg_1[1]));
            window.alert(some("You dragged me!"));
        }),
        onElementsRemove: funcToTuple((tupledArg_2) => {
            console.log(some(tupledArg_2[1]));
            window.alert(some("You removed me!"));
        }),
        onConnect: funcToTuple((tupledArg_3) => {
            console.log(some(tupledArg_3[1]));
            window.alert(some("You connected me!"));
        }),
        onConnectStart: funcToTuple((tupledArg_4) => {
            console.log(some(tupledArg_4[1]));
            window.alert(some("You started to connect me!"));
        }),
    }), (elms_2 = ofArray([createElement("h4", {
        className: "title is-4",
        children: "Features",
    }), (children_2 = ofArray([createElement("li", {
        children: ["column interactions (resize, reorder and pin columns="],
    }), createElement("li", {
        children: ["Pagination"],
    }), createElement("li", {
        children: ["Sorting"],
    }), createElement("li", {
        children: ["Row selection"],
    }), createElement("li", {
        children: ["Data export"],
    })]), createElement("ul", {
        children: Interop_reactApi.Children.toArray(Array.from(children_2)),
    }))]), createElement("div", {
        className: "content",
        children: Interop_reactApi.Children.toArray(Array.from(elms_2)),
    })), fixDocsView("FelizReactFlow", false)]);
    return createElement("div", {
        children: Interop_reactApi.Children.toArray(Array.from(children_5)),
    });
})();

export const installation = installationView("Feliz.ReactFlow");

