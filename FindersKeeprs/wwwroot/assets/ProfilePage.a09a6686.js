import{E as w,C as c,c as n,a as u,o as i,b as p,d as s,t as d,F as g,m as h,p as B,n as I,D as m}from"./vendor.d9716051.js";import{a as _,A as r,_ as k,P as v,l as y}from"./index.3a6959fd.js";class S{async getProfileById(e){const o=await _.get("api/profiles/"+e);r.activeProfile=o.data}async getKeepsByProfileId(e){const o=await _.get("api/profiles/"+e+"/keeps");r.profileKeeps=o.data}async getVaultsByProfileId(e){const o=await _.get("api/profiles/"+e+"/vaults");r.profileVaults=o.data}}const f=new S;const x={setup(){const t=w();return c(()=>{f.getProfileById(t.params.id)}),c(async()=>{try{await f.getKeepsByProfileId(t.params.id)}catch(e){v.toast(e.message,"error"),y.log(e)}}),c(async()=>{try{await f.getVaultsByProfileId(t.params.id)}catch(e){v.toast(e.message,"error"),y.log(e)}}),{profile:n(()=>r.activeProfile),profileKeeps:n(()=>r.profileKeeps),profileVaults:n(()=>r.profileVaults)}}},P=t=>(B("data-v-1fcc1d14"),t=t(),I(),t),C={class:"component container-fluid"},j={class:"row"},A={class:"col d-flex mt-3"},D=["src"],E={class:"p-2"},F={class:"row mt-3"},T=P(()=>s("h4",null,"Vaults:",-1)),b={class:"row mt-3"},L=P(()=>s("h4",null,"Keeps:",-1)),M={class:"masonry"};function N(t,e,o,a,R,q){const V=u("VaultCard"),K=u("Keep");return i(),p("div",C,[s("div",j,[s("div",A,[s("img",{src:a.profile.picture,class:"rounded",height:"150"},null,8,D),s("div",E,[s("h2",null,d(a.profile.name),1),s("h5",null,"Total Vaults: "+d(a.profileVaults.length),1),s("h5",null,"Total Keeps: "+d(a.profileKeeps.length),1)])])]),s("div",F,[T,(i(!0),p(g,null,h(a.profileVaults,l=>(i(),m(V,{key:l.id,vault:l},null,8,["vault"]))),128))]),s("div",b,[L,s("div",M,[(i(!0),p(g,null,h(a.profileKeeps,l=>(i(),m(K,{key:l.id,keep:l},null,8,["keep"]))),128))])])])}var H=k(x,[["render",N],["__scopeId","data-v-1fcc1d14"]]);export{H as default};
