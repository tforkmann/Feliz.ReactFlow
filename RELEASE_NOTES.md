#### 0.3.0-alpha.13 - 2023-12-30
* Update Feliz to v2+
* Update React Flow to v11, adjust the bindings according to the API changes -- see [Migrate to v10](https://reactflow.dev/docs/guides/migrate-to-v10/), [Migrate to v11](https://reactflow.dev/docs/guides/migrate-to-v11/) official guides for the changes details.
* Remove `IStyleProp` and `ILabelStyleProp` types (in favor of `IStyleAttribute` from `Feliz`), adjust corresponding (dependent) prop signatures.
* Add bindings to CSS class helpers `nodrag` and `nowheel` (defined in `Feliz.ReactFlow.Styles.classes`).
* Add the following `Node` prop bindings: `dragHandle`, `zIndex`, `width`, `height`, `ariaLabel`, `parentNode`, `deletable`, `expandParent`, `selected`, `extent`, `positionAbsolute`, `focusable`.
* Add `Handle` prop bindings: `isConnectable`.
* Rename: Node's `nodetype` prop binding to `type'`, Handle's `type` to `type'`.
* Change `NodeType` type: add `Group` case, remove `Custom` case, mark the type as `StringEnum`, remove `toString` member.
* Add `node.type'` overload with `customTypeName: string` as a parameter -- to set a custom Node type (instead of previous way by `NodeType.Custom` DU case).
* Add `node.type'.input`, `node.type'.output`, `node.type'.default'`, `node.type'.group` prop overloads for API simplification.
* Rename `ReactFlow.flowChart` to `ReactFlow.reactFlow`.
* Add ["Graph Util functions"](https://reactflow.dev/docs/api/graph-util-functions/#applynodechanges) bindings as `GraphUtils` type with the following bindings (replaces previously defined `Helpers` module): `isEdge`, `isNode`, `applyNodeChanges`, `applyEdgeChanges`, `addEdge`, `updateEdge`, `getOutgoers`, `getIncomers`, `getConnectedEdges`, `getTransformForBounds`, `getRectOfNodes`, `getViewportForBounds`, `getNodesBounds`.
* Update all the "Keys" ReactFlow props -- reflect the change of ReactFlow's `KeyCode` type to `string | Array<string>`; add missing `panActivationKeyCode` prop binding.
* Add `connectionLineStyle` ReactFlow prop binding.
* Rename `edge.edgeType` to `edge.type'`.
* Rename `HandlePosition` type to `Position`.
* Change `Node`'s `position` prop type from `position` anon. record to `XYPosition` interface.
* Add `edge.type'` overload with `customTypeName: string` as a parameter -- to set a custom Edge type.
* Add `node.data` and `edge.data` overloads that take generic `data: 'T` as a parameter.
* Add bindings to the provided hooks (defined in `Feliz.ReactFlow.Hooks` module as extensions on the `ReactFlow` type): `useReactFlow`, `useNodes`, `useEdges`, `useViewport`, `useOnViewportChange`, `useOnSelectionChange`, `useUpdateNodeInternals`, `useKeyPress`, `useNodesInitialized`, `useStore`, `useNodeId`.
* Add `ReactFlow.reactFlowProvider` helper for creating `ReactFlowProvider` component.
* Add `NodeResizer` component bindings.
* Add `Panel` component bindings.
* Update ReactFlow Instance (`Instance` interface) bindings.
#### 0.2.7 - 2022-05-12
* Add Source and Target Handle in Edge
#### 0.2.6 - 2022-02-23
* Update packages
#### 0.2.5 - 2022-02-22
* Upgrade to .NET6
#### 0.2.4 - 2021-10-11
* try again
#### 0.2.3 - 2021-10-11
* Add Minimap, Background and controls and test as well
#### 0.2.2 - 2021-06-24
* Add ReactFlow props (complete) and helpers (incomplete)
#### 0.2.1 - 2021-06-17
* Add bindings for custom nodes
#### 0.2.0 - 2021-04-23
* Polishing and add more events
#### 0.1.9 - 2021-04-21
* Remove objectAssign
#### 0.1.8 - 2021-04-10
* support netstandard2.0
#### 0.1.7 - 2021-04-09
* Move styles to its own file
#### 0.1.6 - 2021-04-09
* bring back reference
#### 0.1.5 - 2021-04-09
* remove unused packages
#### 0.1.4 - 2021-04-08
* get rid of artifacts
#### 0.1.3 - 2021-04-08
* restructure into namespace
#### 0.1.2 - 2021-04-08
* try again
#### 0.1.1 - 2021-04-08
* Fix Package info
#### 0.1.0 - 2021-04-07
* Initial release
