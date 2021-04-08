import { equals } from "../.fable/fable-library.3.1.2/Util.js";
import { ofSeq } from "../.fable/fable-library.3.1.2/List.js";
import { addEdge as addEdge_1, removeElements as removeElements_1 } from "react-flow-renderer";
import react$002Dflow$002Drenderer from "react-flow-renderer";

export function objectHas(keys, x) {
    return equals(keys, ofSeq(Object.keys(x)));
}

export const reactFlow = react$002Dflow$002Drenderer;

export const removeElements = removeElements_1;

export const addEdge = addEdge_1;

export function funcToTuple(handler) {
    return (a, b) => handler([a, b]);
}

